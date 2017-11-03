/// <reference path="../ajax.js" />
/// <reference path="../../lib/js/alert.js" />
var NotEditAlert;
var ErrorAlert;
var DeleteSuccessAlert;
var AddSuccessAlert;
var DeleteAlert;
var InsertAlert;
var SuccessAlert;
var InsertCardAlert;
//新增新类型卡
function add() {
    className = $(this).attr('class');
    $('#dialogBg').fadeIn(300);
    $('#dialog').removeAttr('class').addClass('animated ' + className + '').fadeIn();
}
function InsertMemberTypeCard() {
    var CardName = $('.editInfos #CardName').val();
    var CardImage = $('.editInfos #result').attr('src');
    jQuery.axpost("MemberCardAjax/Insert_MemberTypeCard", "CardName:'" + CardName + "',CardImage:'" + CardImage + "'"
        , function (data) {
            if (SuccessAlert) {
                SuccessAlert.show();
            }
            else {
                SuccessAlert = jqueryAlert({
                    'content': '新增会员类型卡成功',
                    'closeTime': 2000,

                });
            }
            //添加数据成功后清空文本框内容
            $('.editInfos #CardName').val("");
            $(".Image_Li #result").css("display", "none");
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

//根据ID删除优惠券
function deleteCoupon(MemberShipTypeId, CouponId) {
    var coupon = CouponId;
    DeleteAlert = jqueryAlert({
        'title': '删除提示',
        'content': '您确定要删除吗？',
        'modal': true,
        'buttons': {
            '确定': function () {
                DeleteAlert.close();
                jQuery.axpost("MemberCardAjax/Delete_CouponById", "MemberShipTypeId:'" + MemberShipTypeId + "',CouponId:'" + CouponId + "'", function (data) {
                    $("#Hidden_Search").trigger("click");
                    // 删除成功提示
                    if (DeleteSuccessAlert) {
                        return DeleteSuccessAlert.show();
                    }
                    DeleteSuccessAlert = jqueryAlert({
                        'content': data.Message,
                        'closeTime': 2000,
                    })
                })
            },
            '取消': function () {
                DeleteAlert.close();
            }
        }
    })
}
//添加优惠券
function InsertCoupon(MemberShipTypeId, CouponId) {
    InsertAlert = jqueryAlert({
        'title': '添加提示',
        'content': '您确定要添加吗？',
        'modal': true,
        'buttons': {
            '确定': function () {
                InsertAlert.close();
                jQuery.axpost("MemberCardAjax/Insert_CouponById", "MemberShipTypeId:'" + MemberShipTypeId + "',CouponId:'" + CouponId + "'", function (data) {
                    $("#Hidden_Search").trigger("click");
                    // 添加成功提示
                    if (AddSuccessAlert) {
                        return AddSuccessAlert.show();
                    }
                    AddSuccessAlert = jqueryAlert({
                        'content': data.Message,
                        'closeTime': 2000,
                    })
                })
            },
            '取消': function () {
                InsertAlert.close();
            }
        }
    })
}
//上传图片
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
//添加会员卡
function InsertMemberCard() {
    className = $(this).attr('class');
    $('#dialogBg').fadeIn(300);
    $('#dialog').removeAttr('class').addClass('animated ' + className + '').fadeIn();
}
function Insert_MemberCard(MemberShipTypeId) {
    var CardName = $('table #CardName').val();
    var CardPassword = $('table #CardPassword').val();
    jQuery.axpost("MemberCardAjax/Insert_MemberCard", "CardName:'" + CardName + "',CardPassword:'" + CardPassword + "',MemberShipTypeId:'" + MemberShipTypeId + "'"
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



