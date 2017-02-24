using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EdD
{
    public partial class eddobjrev : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Cookies["IdUsuarioRevisa"].Value=Request.QueryString["id"];
        }
    }
}