<%@ Page Title="" Language="C#" MasterPageFile="~/layout/masterpage/Main2.master"
    AutoEventWireup="true" CodeBehind="Books.aspx.cs" Inherits="EntityDataModelBookstore.Books" %>

<asp:Content ID="Content2" ContentPlaceHolderID="contentPlaceHolder" runat="server">
    <div class="container-fluid">
        <div class="row">
            <h1 class="page-header">
                Books</h1>
            <div class="row placeholders">
                <asp:Repeater ID="BookList" runat="server">
                    <ItemTemplate>
                        <div class="col-xs-6 col-sm-3 placeholder">
                            <img data-src="holder.js/200x200/auto/sky" class="img-responsive" alt="Generic placeholder thumbnail"><h4><%#Eval("Price") %></h4>
                            <span class="text-muted"><%#Eval("BookName") %></span>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
    </div>
</asp:Content>
