using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Transactions;

namespace DEV_Form
{
    public partial class FM_CUST : Form
    {
        private SqlConnection Connect = null;      
        
        private string strConn = "Data Source=61.105.9.203; Initial Catalog=AppDev;User ID=kfqs1;Password=1234";
        public FM_CUST()
        {
            InitializeComponent();
        }
        private void FM_CUST_Load(object sender, EventArgs e)
        {
            try
            {
                // 콤보박스 품목 상세 데이터 조회 및 추가
                // 접속 정보 커넥션 에 등록 및 객체 선언
                Connect = new SqlConnection(strConn);
                Connect.Open();

                if (Connect.State != System.Data.ConnectionState.Open)
                {
                    MessageBox.Show("데이터 베이스 연결에 실패 하였습니다.");
                    return;
                }
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM TB_CUST_PSS", Connect);
                DataTable dtTemp = new DataTable();
                adapter.Fill(dtTemp);


            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                Connect.Close();
            }
        }

        private void btnCustSearch_Click(object sender, EventArgs e)
        {
            try
            {
                dgvCustGrid.DataSource = null;
                Connect = new SqlConnection(strConn);
                Connect.Open();


                if (Connect.State != System.Data.ConnectionState.Open)
                {
                    MessageBox.Show("데이터 베이스 연결에 실패 하였습니다.");
                    return;
                }

                string sCustCode = txtCustCode.Text;
                string sCustName = txtCustName.Text;
                string sCustStartDate = dtpCustStart.Text;
                string sCustEndDate = dtpCustEnd.Text;



                string sBIZTYPE = "";
                string sCUSTTYPE = "";
                if (rdoComV.Checked == true) sBIZTYPE = "상용차 부품";
                if (radioCar.Checked == true) sBIZTYPE = "자동차부품";
                if (rdoCut.Checked == true) sBIZTYPE = "절삭가공";
                if (rdoPump.Checked == true) sBIZTYPE = "펌프압축기";
                if (chkCustOnly.Checked == true) sCUSTTYPE = "C"; 

                SqlDataAdapter Adapter = new SqlDataAdapter("SELECT CUSTCODE,   " +
                                                            "       CUSTTYPE,   " +
                                                            "       CUSTNAME,   " +
                                                            "       BIZCLASS,   " +
                                                            "       BIZTYPE,    " +
                                                            "       CASE WHEN USEFLAG = 'Y' THEN '사용'" +
                                                            "       WHEN USEFLAG = 'N' THEN '미사용' END AS USEFLAG,   " +
                                                            "       FIRSTDATE,  " +
                                                            "       MAKEDATE,   " +
                                                            "       MAKER,      " +
                                                            "       EDITDATE,   " +
                                                            "       EDITOR      " +
                                                            "  FROM TB_CUST_PSS WITH(NOLOCK) " +
                                                            " WHERE CUSTCODE LIKE '%" + sCustCode + "%' " +
                                                            "   AND CUSTNAME LIKE '%" + sCustName + "%' " +
                                                            "   AND CUSTTYPE LIKE '%" + sCUSTTYPE + "%' " +
                                                            "   AND BIZTYPE LIKE '%" + sBIZTYPE + "%' " +
                                                            "   AND FIRSTDATE BETWEEN '" + sCustStartDate + "' AND '" + sCustEndDate + "'", Connect);

                DataTable dtTemp = new DataTable();
                Adapter.Fill(dtTemp);

                if (dtTemp.Rows.Count == 0)
                {
                    dgvCustGrid.DataSource = null;
                    return;
                }
                dgvCustGrid.DataSource = dtTemp;

                dgvCustGrid.Columns["CUSTCODE"].HeaderText = "거래처 코드";
                dgvCustGrid.Columns["CUSTTYPE"].HeaderText = "거래처 타입";
                dgvCustGrid.Columns["CUSTNAME"].HeaderText = "거래처 명";
                dgvCustGrid.Columns["BIZCLASS"].HeaderText = "업태";
                dgvCustGrid.Columns["BIZTYPE"].HeaderText = "종목";
                dgvCustGrid.Columns["USEFLAG"].HeaderText = "사용여부";
                dgvCustGrid.Columns["FIRSTDATE"].HeaderText = "거래일자";
                dgvCustGrid.Columns["MAKEDATE"].HeaderText = "등록일시";
                dgvCustGrid.Columns["MAKER"].HeaderText = "등록자";
                dgvCustGrid.Columns["EDITDATE"].HeaderText = "수정일시";
                dgvCustGrid.Columns["EDITOR"].HeaderText = "수정자";


                dgvCustGrid.Columns["CUSTCODE"].ReadOnly = true;
                dgvCustGrid.Columns["CUSTTYPE"].ReadOnly = true;
                dgvCustGrid.Columns["MAKER"].ReadOnly = true;
                dgvCustGrid.Columns["MAKEDATE"].ReadOnly = true;
                dgvCustGrid.Columns["EDITOR"].ReadOnly = true;
                dgvCustGrid.Columns["EDITDATE"].ReadOnly = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());

            }
            finally
            {
                Connect.Close();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            DataRow dr = ((DataTable)dgvCustGrid.DataSource).NewRow();
            ((DataTable)dgvCustGrid.DataSource).Rows.Add(dr);
            dgvCustGrid.Columns["CUSTCODE"].ReadOnly = false;
            dgvCustGrid.Columns["CUSTTYPE"].ReadOnly = false;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (this.dgvCustGrid.Rows.Count == 0) return;
            if (MessageBox.Show("선택된 데이터를 삭제 하시겠습니까", "데이터 삭제", MessageBoxButtons.OKCancel)
                == DialogResult.No) return;

            SqlCommand cmd = new SqlCommand();
            SqlTransaction tran;

            Connect = new SqlConnection(strConn);
            Connect.Open();

            tran = Connect.BeginTransaction("TranStart");
            cmd.Transaction = tran;
            cmd.Connection = Connect;

            try
            {
                string CustCode = dgvCustGrid.CurrentRow.Cells["CUSTCODE"].Value.ToString();
                cmd.CommandText = "DELETE TB_CUST_PSS WHERE CUSTCODE = '" + CustCode + "'";

                cmd.ExecuteNonQuery();


                tran.Commit();
                MessageBox.Show("정상적으로 삭제 하였습니다.");
                btnCustSearch_Click(null, null);  
            }
            catch
            {
                tran.Rollback();
                MessageBox.Show("데이터 삭제에 실패 하였습니다.");

            }
            finally
            {
                Connect.Close();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (dgvCustGrid.Rows.Count == 0) return;
            if (MessageBox.Show("선택된 데이터를 등록 하시겠습니까?", "데이터등록",
                                 MessageBoxButtons.YesNo) == DialogResult.No) return;


            string sCustCode = dgvCustGrid.CurrentRow.Cells["CUSTCODE"].Value.ToString();
            string sCustType = dgvCustGrid.CurrentRow.Cells["CUSTTYPE"].Value.ToString();
            string sCustName = dgvCustGrid.CurrentRow.Cells["CUSTNAME"].Value.ToString();
            string sBizClass = dgvCustGrid.CurrentRow.Cells["BIZCLASS"].Value.ToString();
            string sBizType = dgvCustGrid.CurrentRow.Cells["BIZTYPE"].Value.ToString();
            string sUseFlag = dgvCustGrid.CurrentRow.Cells["USEFLAG"].Value.ToString();
            string sFirstDate = dgvCustGrid.CurrentRow.Cells["FIRSTDATE"].Value.ToString();

            SqlCommand cmd = new SqlCommand();
            SqlTransaction Tran;

            Connect = new SqlConnection(strConn);
            Connect.Open();

            Tran = Connect.BeginTransaction("TestTran");
            cmd.Transaction = Tran;
            cmd.Connection = Connect;

            if (sCustCode == "" || sCustType == "" || sFirstDate == "")
            { MessageBox.Show("거래처 코드, 거래처 타입 및 거래 일자를 확인하세요"); return; }

            if (sCustType == "고객사")
                sCustType = "C";
            else if (sCustType == "협력사")
                sCustType = "V";
            else { sCustType = "C";}

            if (sUseFlag == "사용")
                sUseFlag = "Y";
            else if (sUseFlag == "미사용")
                sUseFlag = "N";
            else { sUseFlag = "Y"; }

            cmd.CommandText = "UPDATE TB_CUST_PSS                            " +
                              "   SET CUSTNAME   = '" + sCustName       + "'," + 
                              "       BIZCLASS   = '" + sBizClass       + "'," +
                              "       BIZTYPE    = '" + sBizType        + "'," +
                              "       USEFLAG    = '" + "N"             + "'," +
                              "       FIRSTDATE  = '" + sFirstDate      + "'," +
                              "       EDITOR     = '" + Common.LogInID  + "'," +
                              "       EDITDATE   = GETDATE()                 " +
                              " WHERE CUSTCODE   = '" + sCustCode       + "' " +
                              "    IF (@@ROWCOUNT =0)                        " +
                              "INSERT INTO TB_CUST_PSS(CUSTCODE, CUSTTYPE, CUSTNAME, BIZCLASS, BIZTYPE, USEFLAG, FIRSTDATE, MAKEDATE, MAKER) " +
                              "VALUES ('" + sCustCode + "','" + sCustType + "','" + sCustName + "','" + sBizClass + "','" + sBizType + "','" + "N" + "','" + sFirstDate + "',GETDATE(),'" + Common.LogInID + "')";

            cmd.ExecuteNonQuery();

            Tran.Commit();
            MessageBox.Show("정상적으로 등록 하였습니다.");
            Connect.Close();
        }
    }
}
