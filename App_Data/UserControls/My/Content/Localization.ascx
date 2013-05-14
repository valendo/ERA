<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Localization.ascx.cs"
    Inherits="C1Function" %>

<asp:Panel ID="panelContent" runat="server">
    <asp:DropDownList ID="cmbResources" runat="server" AutoPostBack="true" OnSelectedIndexChanged="cmbResources_SelectedIndexChanged"
        Width="275px">
    </asp:DropDownList>
    <br />
    <br />
    <asp:DataGrid ID="gridView1" runat="server" AutoGenerateColumns="False" CellPadding="4"
        ForeColor="#333333" GridLines="None" Width="275px">
        <Columns>
            <asp:TemplateColumn HeaderText="Key">
                <ItemTemplate>
                    <%# DataBinder.Eval(Container,"DataItem.Key") %>
                </ItemTemplate>
            </asp:TemplateColumn>
            <asp:TemplateColumn HeaderText="Value">
                <ItemTemplate>
                    <%# DataBinder.Eval(Container,"DataItem.Value") %>
                </ItemTemplate>
            </asp:TemplateColumn>
            <asp:TemplateColumn>
                <ItemTemplate>
                    <a href='/Page({<%# Composite.Data.SitemapNavigator.CurrentPageId%>})?key=<%# DataBinder.Eval(Container,"DataItem.Key") %>&file=<%=cmbResources.SelectedItem.Text %>'>
                        Edit</a>
                </ItemTemplate>
            </asp:TemplateColumn>
        </Columns>
        <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
        <SelectedItemStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
        <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
        <AlternatingItemStyle BackColor="White" />
        <ItemStyle BackColor="#FFFBD6" ForeColor="#333333" Font-Size="Small" Font-Names="verdana" />
        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
    </asp:DataGrid>
    <br />
    <asp:Panel runat="server" ID="panelUpdate" Visible="false">
        <div>
            <asp:Label ID="lblKey" runat="server"></asp:Label>: <asp:TextBox ID="txtResourceValue" runat="server"></asp:TextBox><br />
            <br />
            <asp:Button ID="btnUpdate" runat="server" Text="Update" 
                OnClick="btnUpdate_Click" />
            <asp:Label ID="lblStatus" runat="server"></asp:Label><br />
            <br />
        </div>
    </asp:Panel>
</asp:Panel>
<asp:Label ID="lblMsg" runat="server" Text="You don't have permission to view this page!!!" ForeColor="Red" Font-Size="Large" Visible="false"/>

