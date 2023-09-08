
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using NITGEN.SDK.NBioBSP;


namespace WinFormsApp1
{
    public partial class Form1 : Form
    {

        MySqlCommand sql;
        Connection con = new Connection();
        public Form1()
        {
            InitializeComponent();
        }

        // Salva usuário no banco
        public DataTable SaveUser(int id, string name, string template)
        {
            try
            {
                con.AbrirConexao();
                sql = new MySqlCommand("INSERT INTO users (id, name, template) values ('"+ id +"' ,'" + name + "', '" + template + "' )", con.con);
                MySqlDataAdapter da = new MySqlDataAdapter();
                da.SelectCommand = sql;
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Busca lista de templates com id
        public DataTable GetUsers()
        {
            try
            {
                con.AbrirConexao();
                sql = new MySqlCommand("SELECT id, template FROM users", con.con);
                MySqlDataAdapter da = new MySqlDataAdapter();
                da.SelectCommand = sql;
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public string template()
        {
            NBioAPI m_NBioAPI = new NBioAPI();
            NBioAPI.Type.HFIR hCapturedFIR;
            NBioAPI.Type.FIR_TEXTENCODE textSavedFIR;
            ErrorProvider error = new ErrorProvider();

            m_NBioAPI.OpenDevice(NBioAPI.Type.DEVICE_ID.AUTO);
            uint ret = m_NBioAPI.Capture(out hCapturedFIR);
            if (ret != NBioAPI.Error.NONE)
            {
                m_NBioAPI.CloseDevice(NBioAPI.Type.DEVICE_ID.AUTO);

                MessageBox.Show("Erro ao capturar a digital");
                //error.SetError(TbId, "Erro ao capturar a digital");
            }
            m_NBioAPI.GetTextFIRFromHandle(hCapturedFIR, out textSavedFIR, true);

            return textSavedFIR.TextFIR;
        }

        //Salva os dados mp banco
        private void TbSave_Click(object sender, EventArgs e)
        {
            SaveUser(Convert.ToInt32(TbId.Text)  ,TbName.Text, template());
        }

        //Busca e identifica
        private void BtnListar_Click(object sender, EventArgs e)
        {
            uint id;
            DataTable dt = GetUsers();
            NBioAPI m_NBioAPI = new NBioAPI();
            NBioAPI.IndexSearch m_IndexSearch = new NBioAPI.IndexSearch(m_NBioAPI);
            NBioAPI.IndexSearch.FP_INFO[] fpInfo;
            NBioAPI.IndexSearch.CALLBACK_INFO_0 cbInfo = new NBioAPI.IndexSearch.CALLBACK_INFO_0();
            NBioAPI.Type.FIR_TEXTENCODE textSavedFIR = new NBioAPI.Type.FIR_TEXTENCODE();
            m_IndexSearch.InitEngine();

            foreach (DataRow row in dt.Rows)
            {
                textSavedFIR.TextFIR = row["template"].ToString();
         
                m_IndexSearch.AddFIR(textSavedFIR, (uint)(Int32)row["id"], out fpInfo);
            }

            m_IndexSearch.GetDataCount(out uint dataCount);

            m_NBioAPI.OpenDevice(NBioAPI.Type.DEVICE_ID.AUTO);
            uint ret = m_NBioAPI.Capture(NBioAPI.Type.FIR_PURPOSE.VERIFY, out NBioAPI.Type.HFIR hCapturedFIR, NBioAPI.Type.TIMEOUT.DEFAULT, null, null);
            if (ret != NBioAPI.Error.NONE)
            {
                m_IndexSearch.TerminateEngine();
                MessageBox.Show("Erro ao capturar a digital");
            }
            m_NBioAPI.CloseDevice(NBioAPI.Type.DEVICE_ID.AUTO);

            ret = m_IndexSearch.IdentifyData(hCapturedFIR, NBioAPI.Type.FIR_SECURITY_LEVEL.NORMAL, out NBioAPI.IndexSearch.FP_INFO returnedFpInfo, cbInfo);
            if (ret != NBioAPI.Error.NONE)
            {
                MessageBox.Show("Erro ao identificar a digital");
            }
            else
            {
                MessageBox.Show("Usuário encontrado: " + returnedFpInfo.ID);
                label5.Text = (returnedFpInfo.ID).ToString();
            }
            m_IndexSearch.TerminateEngine();
        }
    }
}