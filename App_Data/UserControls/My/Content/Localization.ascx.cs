using System;
using Composite.Functions;
using System.IO;
using System.Web.UI.WebControls;
using System.Collections;
using System.Resources;
using Composite.C1Console;
using Composite.Data;
using System.Xml;
using Composite.C1Console.Security;

public partial class C1Function : Composite.AspNet.UserControlFunction
{
    public string filename;

    public override string FunctionDescription
    {
        get 
        { 
            return "A demo function that outputs a hello message."; 
        }
    }

    [FunctionParameter(DefaultValue = "World")]
    public string Name { get; set; }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (UserValidationFacade.IsLoggedIn())
            {
                panelContent.Visible = true;
                lblMsg.Visible = false;
            
            
                    string resourcespath = Request.PhysicalApplicationPath + "App_GlobalResources";
                    DirectoryInfo dirInfo = new DirectoryInfo(resourcespath);
                    foreach (FileInfo filInfo in dirInfo.GetFiles())
                    {
                        string filename = filInfo.Name;
                        cmbResources.Items.Add(filename);
                    }
                    cmbResources.Items.Insert(0, new ListItem("Select a Resource File"));
                    Edit();
            
            }
            else
            {
                panelContent.Visible = false;
                lblMsg.Visible = true;
            }
        }
    }

    protected void Edit()
    {
        if (Request.QueryString["key"] != null && Request.QueryString["file"] != null)
        {
            panelUpdate.Visible = true;
            filename = Request.QueryString["file"];
            filename = Request.PhysicalApplicationPath + "App_GlobalResources\\" + filename;
            string key = Request.QueryString["key"];
            lblKey.Text = key;
            ResXResourceSet rset = new ResXResourceSet(filename);
            txtResourceValue.Text = rset.GetString(key);
        }
    }

    protected void cmbResources_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (cmbResources.SelectedIndex != 0)
        {
            panelUpdate.Visible = false;
            string filename = Request.PhysicalApplicationPath + "App_GlobalResources\\" + cmbResources.SelectedItem.Text;
            Stream stream = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.Read);
            ResXResourceReader RrX = new ResXResourceReader(stream);
            IDictionaryEnumerator RrEn = RrX.GetEnumerator();
            SortedList slist = new SortedList();
            while (RrEn.MoveNext())
            {
                slist.Add(RrEn.Key, RrEn.Value);
            }
            RrX.Close();
            stream.Dispose();
            gridView1.DataSource = slist;
            gridView1.DataBind();
        }
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        filename = Request.QueryString["file"];
        int id = Convert.ToInt32(Request.QueryString["id"]);
        filename = Request.PhysicalApplicationPath + "App_GlobalResources\\" + filename;
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.Load(filename);
        XmlNodeList nlist = xmlDoc.GetElementsByTagName("data");
        XmlNode childnode = nlist.Item(id);
        childnode.Attributes["xml:space"].Value = "default";
        xmlDoc.Save(filename);
        XmlNode lastnode = childnode.SelectSingleNode("value");
        lastnode.InnerText = txtResourceValue.Text;
        xmlDoc.Save(filename);
        lblStatus.Text = "Updated!!!";
    }
}