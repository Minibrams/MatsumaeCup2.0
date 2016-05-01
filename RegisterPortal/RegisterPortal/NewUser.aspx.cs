using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
namespace RegisterPortal
{
    public partial class NewUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Login"] != null)
            {
                Label3.Text = Session["User"].ToString();
                Button6.Visible = true;
            }
            if (Session["Ok"] == null)
            {
                Ok.Visible = false;
                NotOk.Visible = false;
            }
            else if (Session["OK"].ToString() == "OK")
            {
                Ok.Visible = true;
                NotOk.Visible = false;
            }
            else if (Session["OK"].ToString() == "NotOK")
            {
                Ok.Visible = false;
                NotOk.Visible = true;
            }
        }
        protected void Page_Unload(object sender, EventArgs e)
        {
            Session["Ok"] = null;
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            if (TextBoxUsername.Text != "" && TextBoxFirstname.Text != "" && TextBoxLastname.Text != "" && TextBoxEmail.Text !="" && TextBoxCountryCode.Text != "" && TextBoxPhone.Text != "" && TextBoxPhone.Text.Length >= 8)
            {
                Connexion.Cn.Open();
                Connexion.cmd = Connexion.Cn.CreateCommand();
                Connexion.cmd.CommandType = CommandType.Text;
                Connexion.cmd.CommandText = ("INSERT INTO [User] values('" + TextBoxUsername.Text + "','" + 1234 + "','" + TextBoxFirstname.Text + "','" + TextBoxLastname.Text + "','" + TextBoxEmail.Text + "','" + TextBoxCountryCode + " " + TextBoxPhone.Text + "','" + TextBoxClub.Text + "')");
                Connexion.cmd.ExecuteNonQuery();
                Session["Login"] = TextBoxUsername.Text;
                Session["User"] = TextBoxFirstname.Text;
                Connexion.Cn.Close();
                Ok.Visible = true;
                Session["Ok"] = "Ok";
                Response.Redirect("Sigin.aspx");
                
            }
            else
            {
                Connexion.Cn.Close();
                Session["Ok"] = "NotOk";
                NotOk.Visible = true;
            }
            

        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            TextBoxCountryCode.Text = DropDownList1.SelectedValue;
        }

        protected void DropDownList1_DataBinding(object sender, EventArgs e)
        {
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Welcome.aspx");
        }
    }
}