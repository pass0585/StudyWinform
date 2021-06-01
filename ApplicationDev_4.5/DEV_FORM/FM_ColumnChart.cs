using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DEV_FORM
{
    public partial class FM_ColumnChart : DEV_FORM.BaseMDIChildForm
    {
        private DataTable empty = new DataTable();
        public FM_ColumnChart()
        {
            InitializeComponent();
        }

        private void FM_ColumnChart_Load(object sender, EventArgs e)
        {
            DBHelper hp = new DBHelper(false);
            try
            {
                DataTable dttemp = new DataTable();
                dttemp = hp.FillTable("SP_CHART_PSS_S1",CommandType.StoredProcedure
                           ,hp.CreateParameter("ITEMCODE","")); // 빈 파라미터 투척..!
                if(dttemp.Rows.Count == 0)
                {
                    return;
                }
                else
                {
                    comboBox1.DataSource = dttemp;
                    comboBox1.DisplayMember = "ITEMNAME";
                    comboBox1.ValueMember = "ITEMCODE";

                }

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                hp.Close();
            }
            empty.Columns.Add("PRODDATE");
            empty.Columns.Add("ITEMCODE");
            empty.Columns.Add("ITEMNAME");
            empty.Columns.Add("PRODCOUNT");
            dataGridView1.DataSource = empty;

            //빈 테이블 생성(데이터그리드뷰 세팅
            //화면이 열릴때 그리드뷰에 비어있는 데이터 테이블 미리 등록한다. 
            //그리드 뷰의 헤더 명칭 설정
            dataGridView1.Columns["PRODDATE"].HeaderText = "생산일자";
            dataGridView1.Columns["ITEMCODE"].HeaderText = "품목코드";
            dataGridView1.Columns["ITEMNAME"].HeaderText = "품목명";
            dataGridView1.Columns["PRODCOUNT"].HeaderText = "생산수량";

            dataGridView1.Columns[0].Width = 200;
            dataGridView1.Columns[1].Width = 200;
            dataGridView1.Columns[2].Width = 200;
            dataGridView1.Columns[3].Width = 200;

            //컬럼의 수정 여부를 지정한다.
            dataGridView1.Columns[0].ReadOnly = true;
            dataGridView1.Columns[1].ReadOnly = true;
            dataGridView1.Columns[2].ReadOnly = true;
            dataGridView1.Columns[3].ReadOnly = true;

        }

        public override void Inquire()
        {
            base.Inquire();
            DBHelper helper = new DBHelper(false);
            try
            {
                string sItemCode = comboBox1.SelectedValue.ToString();
                DataTable dtTemp = new DataTable();
                dtTemp = helper.FillTable("SP_CHART_PSS_S2", CommandType.StoredProcedure
                                          , helper.CreateParameter("ITEMCODE", sItemCode));
                if (dtTemp.Rows.Count == 0)
                {
                    dataGridView1.DataSource = empty;
                    MessageBox.Show("조회할 데이터가 없습니다.");
                }
                else
                {
                    // 그리드뷰에 데이터 삽입
                    dataGridView1.DataSource = dtTemp;

                    // 컬럼차트 생성
                    MakeColumnChart(helper, sItemCode);
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                helper.Close();
            }
        
        }

        private void MakeColumnChart(DBHelper helper, string sItemCode)
        {
            DataTable dtTemp = new DataTable();
            chart1.Series.Clear();
            dtTemp = helper.FillTable("SP_CHART_PSS_S3"
                                            , CommandType.StoredProcedure
                                            , helper.CreateParameter("ITEMCODE",sItemCode));
            if(dtTemp.Rows.Count==0)
            {
                return;
            }
            // 데이터 테이블을 차트에 바인딩 한다.
            chart1.DataBindTable(dtTemp.DefaultView, "PRODDATE");
            // 바인딩 된 시리즈의 이름을 지정한다.
            chart1.Series[0].Name = dtTemp.Rows[0]["ITEMNAME"].ToString();
            chart1.Series[0].Color               = Color.Green; // 차트의 색상 변경
            chart1.Series[0].IsValueShownAsLabel = true;        // 차트에 값 표시
        }
    }
}
