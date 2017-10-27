/// <reference path="../ajax.js" />
/// <reference path="../../lib/js/alert.js" />
var SuccessAlert;
var ErrorAlert;
//新增电子储值卡
function add() {
    className = $(this).attr('class');
    $('#dialogBg').fadeIn(300);
    $('#dialog').removeAttr('class').addClass('animated ' + className + '').fadeIn();
      
}

function InsertElectronicType() {
    var CardName = $('.editInfos #CardName').val();
    var CardImage = $('.editInfos #CardImage').val();
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
            $('.editInfos #CardImage').val("");
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
