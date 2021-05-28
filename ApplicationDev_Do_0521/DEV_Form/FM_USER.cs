using Dev_Form;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DEV_Form
{
    public partial class FM_USER : BaseMDIChildForm
    {
        public FM_USER()
        {
            InitializeComponent();
        }

        public override void Inquire()
        {
            base.Inquire();

            // DB HELPER 선언
            DBHelper helper = new DBHelper(false);
            try
            {
                string sUserId = txtUserID.Text;
                string sUserName = txtUserName.Text;
                DataTable dtTemp = new DataTable();
                dtTemp = helper.FillTable("SP_USER_PSS_S1", CommandType.StoredProcedure,
                            helper.CreateParameter("USERID", sUserId), 
                            helper.CreateParameter("USERNAME", sUserName));
                
                if(dtTemp.Rows.Count == 0)
                {
                    dataGridView1.DataSource = null;
                    MessageBox.Show("조회할 데이터가 없습니다");
                }
                else
                {
                    dataGridView1.DataSource = dtTemp;
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
            finally { helper.Close(); }
        }
        public override void Save()
        {
            base.Save();
            string UserId = string.Empty;
            string sUserName = string.Empty;
            string sPassWord = string.Empty;

            DataTable dtTemp = ((DataTable)dataGridView1.DataSource).GetChanges();  //get changes 바뀐부분 체크 바뀐내용만 dtTemp에 들어감
            if (dtTemp == null) return; 

            if (MessageBox.Show("데이터를 등록 하시겠습니까?", "데이터 저장",
               MessageBoxButtons.YesNo) == DialogResult.No) return;
            DBHelper helper = new DBHelper(true);
            try
            {
                //트랜잭션
                foreach (DataRow drRow in dtTemp.Rows)
                {
                    switch(drRow.RowState)
                    {
                        case DataRowState.Deleted:
                            drRow.RejectChanges();  // 지워지기 전 데이터 복구
                            UserId = drRow["USERID"].ToString();
                            helper.ExecuteNoneQuery("SP_USER_PSS_D1", CommandType.StoredProcedure
                                                    , helper.CreateParameter("USERID", UserId));
                            break;

                        case DataRowState.Added:
                            #region 추가
                            UserId = drRow["USERID"].ToString();
                            sUserName = drRow["USERNAME"].ToString();
                            sPassWord = drRow["PW"].ToString();
                            helper.ExecuteNoneQuery("SP_USER_PSS_I1", CommandType.StoredProcedure
                                , helper.CreateParameter("USERID", UserId)
                                , helper.CreateParameter("USERNAME", sUserName)
                                , helper.CreateParameter("PASSWORD", sPassWord)
                                , helper.CreateParameter("MAKER", Common.LogInID)
                                );
                            #endregion
                            break;

                        case DataRowState.Modified:
                            #region 수정
                            UserId = drRow["USERID"].ToString();
                            sUserName = drRow["USERNAME"].ToString();
                            sPassWord = drRow["PW"].ToString();
                            helper.ExecuteNoneQuery("SP_USER_PSS_U1", CommandType.StoredProcedure
                                , helper.CreateParameter("USERID", UserId)
                                , helper.CreateParameter("USERNAME", sUserName)
                                , helper.CreateParameter("PASSWORD", sPassWord)
                                , helper.CreateParameter("EDITOR", Common.LogInID)
                                );
                            #endregion
                            break;


                    }
                }

                //성공 시 DB COMMIT
                helper.Commit();
                // 메세지
                MessageBox.Show("정상적으로 등록 하였습니다.");
                // 재조회
                Inquire();
            }
            catch (Exception ex)
            {
                // 트랜잭션 롤백
                helper.Rollback();
                MessageBox.Show("데이터 등록에 실패 하였습니다.");

            }
            finally { helper.Close(); }
        }   

        public override void DoNew()
        {
            base.DoNew();
            DataRow dr = ((DataTable)dataGridView1.DataSource).NewRow();
            ((DataTable)dataGridView1.DataSource).Rows.Add(dr);
        }
        public override void Delete()
        {
            base.Delete();
            if (dataGridView1.Rows.Count == 0) return;

            string sUserId = dataGridView1.CurrentRow.Cells["USERID"].Value.ToString();
            DataTable dtTemp = (DataTable)dataGridView1.DataSource;
            for (int i = 0; i < dtTemp.Rows.Count; i++)
            {
                if (dtTemp.Rows[i].RowState == DataRowState.Deleted) continue;
                if (dtTemp.Rows[i][0].ToString() == sUserId)
                {
                    dtTemp.Rows[i].Delete();
                    break;
                }
            }

            /*int iSelectIndex = dataGridView1.CurrentCell.RowIndex;
            DataTable dtTemp = (DataTable)dataGridView1.DataSource;
            dtTemp.Rows[iSelectIndex].Delete();*/
        
        }

    }
}
