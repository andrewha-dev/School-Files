<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="polka.aspx.cs" Inherits="aha_C40_L08.polka" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<!DOCTYPE html>
<link href="styles/accordion.css" rel="stylesheet" />
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="styles/accordion.css" rel="stylesheet" />
</head>
<body>

    <form id="form1" runat="server">
    <div>
        <asp:ScriptManager ID="smPolka" runat="server"></asp:ScriptManager>
        <ajaxToolkit:Accordion ID="accPanel1" runat="server" CssClass="accordion" HeaderCssClass="headerclass" HeaderSelectedCssClass="headerselected" ContentCssClass="contentclass">
            <Panes>
                <ajaxToolkit:AccordionPane ID="AccordionPane1" runat="server">
                    <Header>
                        Panel 1
                    </Header>
                    <Content>
                        <asp:Label ID="lblPanel1" runat="server" Text="Label Inside Panel 1"></asp:Label>
                        <br />
                        <asp:Button ID="btnPanel1" runat="server" Text="I am a button" />
                    </Content>
                </ajaxToolkit:AccordionPane>
                <ajaxToolkit:AccordionPane ID="AccordionPane2" runat="server">
                    <Header>
                        Panel 2
                    </Header>
                    <Content>
                        <div>
                        <asp:TextBox ID="txtDate" runat="server"></asp:TextBox>
                        <ajaxToolkit:CalendarExtender ID="calPanel2" runat="server" TargetControlID="txtDate" />
                        </div>
                        
                    </Content>
                </ajaxToolkit:AccordionPane>
                <ajaxToolkit:AccordionPane ID="AccordionPane3" runat="server">
                    <Header>
                        Panel 3
                    </Header>
                    <Content>
                        <ajaxToolkit:PieChart ID="PieChart1" runat="server" ChartTitle="Computer Science in my life">
                            <PieChartValues>
                                <ajaxToolkit:PieChartValue Category="Assignments" Data="49"
                                    PieChartValueColor="#6C1E83" PieChartValueStrokeColor="black" />
                                <ajaxToolkit:PieChartValue Category="Labs" Data="10"
                                    PieChartValueColor="#D08AD9" PieChartValueStrokeColor="black" />
                                <ajaxToolkit:PieChartValue Category="Home" Data="1"
                                    PieChartValueColor="#6586A7" PieChartValueStrokeColor="black" />
                                <ajaxToolkit:PieChartValue Category="Depression" Data="40"
                                    PieChartValueColor="#0E426C" PieChartValueStrokeColor="black" />
                            </PieChartValues>
                        </ajaxToolkit:PieChart>
                    </Content>
                </ajaxToolkit:AccordionPane>
            </Panes>
        </ajaxToolkit:Accordion>
        <h1>Here is Accordion #2 below!</h1>
        <ajaxToolkit:Accordion ID="accPanel2" runat="server" HeaderSelectedCssClass="headerselected" HeaderCssClass="headerclass" CssClass="accordion" ContentCssClass="contentclass">

        </ajaxToolkit:Accordion>
    </div>
    </form>
</body>
</html>
