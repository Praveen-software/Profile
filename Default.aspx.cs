using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void submit_Click(object sender, EventArgs e)
    {
        SendMail();
    }
    public void SendMail()
    {
        try
        {
            string fromemail = txtemail.Text;
            string fromname = txtname.Text;
            string frommessage = txtmessage.Text;
          
        

            string toEmail = "praveensoftweb@gmail.com";
            MailMessage mail = new MailMessage();
            mail.To.Add(toEmail);

            mail.From = new MailAddress("iscconline@yahoo.com");
            mail.Subject = "PortFolio Enquiry";
            string body = fromname + "/" + fromemail + "/" + frommessage;
            body = body.Replace("/", System.Environment.NewLine);
            mail.Body = body;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.mail.yahoo.com";

            smtp.Port = 25;
            smtp.UseDefaultCredentials = true;
            smtp.Credentials = new System.Net.NetworkCredential("iscconline@yahoo.com", "ISCC@MEP");
            smtp.EnableSsl = true;
            smtp.Send(mail);

            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Thanks for contacting us!!!');", true);

        }
        catch (Exception)
        {
            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Something went wrong');", true);

        }
    }
}