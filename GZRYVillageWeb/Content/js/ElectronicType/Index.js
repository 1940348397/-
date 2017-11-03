/// <reference path="../ajax.js" />
/// <reference path="../../lib/js/alert.js" />
var SuccessAlert;
var ErrorAlert;
//新增电子储值卡类型
function add() {
    className = $(this).attr('class');
    $('#dialogBg').fadeIn(300);
    $('#dialog').removeAttr('class').addClass('animated ' + className + '').fadeIn();

}

function InsertElectronicType() {
    var CardName = $('.editInfos #CardName').val();
    var CardImage = $('.editInfos #result').attr('src');
    var CardMoney = $('.editInfos #CardMoney').val();
    jQuery.axpost("ElectronicCardAjax/Insert_ElectronicType", "CardName:'" + CardName + "',CardImage:'" + CardImage + "',CardMoney:'" + CardMoney + "'"
        , function (data) {
            if (SuccessAlert) {
                SuccessAlert.show();
            }
            else {
                SuccessAlert = jqueryAlert({
                    'content': '新增电子储值卡成功',
                    'closeTime': 2000,

                });
            }
            //添加数据成功后清空文本框内容
            $('.editInfos #CardName').val("");
            $(".Image_Li #result").css("display", "none");
            $('.editInfos #CardMoney').val("");
            CloseDialog();
            //调用 search 的点击事件的两种方法
            $("#search").trigger("click");
            return;
        }, ErrorAlert);
}

function CloseDialog() {
    $('#dialogBg').fadeOut(300, function () {
        $('#dialog').addClass('bounceOutUp').fadeOut();
    });
}


//上传电子储值卡图片
$(function () {
    $("#btn_show").bind("click", function () {
        $("#form_upload #upImg").trigger("click");
        var options = {
            success: function (responseText, statusText, xhr, $form) {
                var picPath = responseText.pic;
                if (picPath == "") {
                    alert(responseText.error);
                }
                else {
                    $("#form_upload").hide();
                    $("#result").attr("src", picPath).show();
                }
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                console.log(textStatus);
                console.log(errorThrown);
            }
        };

        $("#form_upload").ajaxForm(options);
    });
    $("#upImg").bind("change", function () {
        $("#form_upload #Sumbit_Img").trigger("click");
        $(".Image_Li #result").css("display", "block");
    });
    $("#btn_show").bind();
})
//新增电子储值卡
function AddElectronicCard() {
    className = $(this).attr('class');
    $('#dialogBg').fadeIn(300);
    $('#dialog').removeAttr('class').addClass('animated ' + className + '').fadeIn();

};

function Insert_ElectronicCard(ElectronicTypeId) {
    var CardName = $('table #CardName').val();
    var CardPassword = $('table #CardPassword').val();
    jQuery.axpost("MemberCardAjax/Insert_MemberCard", "CardName:'" + CardName + "',CardPassword:'" + CardPassword + "',ElectronicTypeId:'" + ElectronicTypeId + "'"
        , function (data) {
            if (InsertCardAlert) {
                InsertCardAlert.show();
            }
            else {
                InsertCardAlert = jqueryAlert({
                    'content': '新增会员卡成功',
                    'closeTime': 2000,

                });
            }
            //添加数据成功后清空文本框内容
            $('table #CardName').val("");
            $('table #CardPassword').val("");
            CloseDialog1();
            //调用 search 的点击事件的两种方法
            $("#search").trigger("click");
            return;
        }, ErrorAlert);
}

function CloseDialog1() {
    $('#dialogBg').fadeOut(300, function () {
        $('#dialog').addClass('bounceOutUp').fadeOut();
    });
}