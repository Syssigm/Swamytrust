<%@ Page Title="" Language="C#" MasterPageFile="~/Siddeswariafterlogin.Master" AutoEventWireup="true" CodeBehind="Success.aspx.cs" Inherits="Siddeswari.Success" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid welcome-content">
        <div class="container">
            <div class="card">
                <div class="card-body">
                    <div class="alert alert-danger">
                        <strong>Some error occured, please try again.</strong>
                    </div>
                    <div class="alert alert-success">
                        <strong>You have done this transaction successfully</strong>
                    </div>
                    <p>Transaction ID:</p>
                    <p>Payment Mode:</p>
                </div>

            </div>

        </div>
    </div>
</asp:Content>
