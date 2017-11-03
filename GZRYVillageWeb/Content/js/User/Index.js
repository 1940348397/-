/// <reference path="../ajax.js" />
/// <reference path="../../lib/js/alert.js" />
var NotEditAlert;
var PassWordAlert;
var ErrorAlert;
var SuccessUpdateAlert;
var SuccessAddAlert;
var NotSuccessAlert;

//新增用户信息
function add() {
    className = $(this).attr('class');
    $('.box1 #dialogBg').fadeIn(300);
    $('.box1 #dialog').removeAttr('class').addClass('animated ' + className + '').fadeIn();
}
function InsertUserInfo() {
    var UserName = $('.box1 table #UserName').val();
    var UserNickName = $('.box1 table #UserNickName').val();
    var UserPhone = $('.box1 table #UserPhone').val();
    var UserEmail = $('.box1 table #UserEmail').val();
    var Sex = GetRedioValue('.box1 table input[name="sex-insert"]');
    var ConsumptionTime = $('.box1 table #ConsumptionTime').val();
    jQuery.axpost("UserAjax/Insert_UserInfo", "UserName:'" + UserName +
                                          "',UserNickName:'" + UserNickName +
                                          "',UserPhone:'" + UserPhone +
                                          "',UserEmail:'" + UserEmail +
                                          "',sex:'" + Sex +
                                          "',ConsumptionTime:'" + ConsumptionTime + "'"
        , function (data) {
            if (SuccessAddAlert) {
                SuccessAddAlert.show();
            }
            else {
                SuccessAddAlert = jqueryAlert({
                    'content': '新增用户成功',
                    'closeTime': 2000,

                });
            }
            //添加数据成功后清空文本框内容
            $('.box1 table #UserName').val("");
            $('.box1 table #UserNickName').val("");
            $('.box1 table #UserPhone').val("");
            $('.box1 table #UserEmail').val("");
            $('.box1 table input[name="sex-insert"]').removeAttr("checked");
            $('.box1 table #ConsumptionTime').val("");
            CloseDialog1();
            //调用 search 的点击事件的两种方法
            $("#search").trigger("click");
            return;
        }, ErrorAlert);
}
function CloseDialog1() {
    $('.box1 #dialogBg').fadeOut(300, function () {
        $('.box1 #dialog').addClass('bounceOutUp').fadeOut();
    });
};


//修改用户信息
function modify(UserId) {
    jQuery.axpost("UserAjax/Get_User_ById", "UserId:'" + UserId + "'", function (data) {
        className = $(this).attr('class');
        $('.box #dialogBg').fadeIn(300);
        $('.box #dialog').removeAttr('class').addClass('animated ' + className + '').fadeIn();
        SetValue('.box table #UserName', data.Model1.UserName);
        SetValue('.box table #UserNickName', data.Model1.UserNickName);
        SetValue('.box table #UserPhone', data.Model1.UserPhone);
        SetValue('.box table #UserEmail', data.Model1.UserEmail);
        SetSexValue('.box table input[name="sex"]', data.Model1.Sex);
        SetValue('.box table #ConsumptionTime', data.Model1.ConsumptionTime);
        $('.box table #Modify_User').attr('onclick', 'modifyUserInfo(' + data.Model1.UserId + ')');
        return;
    }, ErrorAlert);
}
function modifyUserInfo(UserId) {
    var UserName = $('.box table #UserName').val();
    var UserNickName = $('.box table #UserNickName').val();
    var UserPhone = $('.box table #UserPhone').val();
    var UserEmail = $('.box table #UserEmail').val();
    var Sex = GetRedioValue('.box table input[name="sex"]');
    var ConsumptionTime = $('.box table #ConsumptionTime').val();
    if (Compare('.box table #UserName') && Compare('.box table #UserNickName') && Compare('.box table #UserPhone') && Compare('.box table #UserEmail') && Compare('.box table #ConsumptionTime') && CompareSex('.box table input[name="sex"]')) {
        if (NotEditAlert) {
            NotEditAlert.show();
        }
        else {
            NotEditAlert = jqueryAlert({
                'content': '并未修改任何信息',
                'closeTime': 2000,
            });
        }
        return;
    }
    jQuery.axpost("UserAjax/Modify_User", "UserId:'" + UserId +
                                          "',UserName:'" + UserName +
                                          "',UserNickName:'" + UserNickName +
                                          "',UserPhone:'" + UserPhone +
                                          "',UserEmail:'" + UserEmail +
                                          "',sex:'" + Sex +
                                          "',ConsumptionTime:'" + ConsumptionTime + "'"
        , function (data) {
            if (SuccessUpdateAlert) {
                SuccessUpdateAlert.show();
            }
            else {
                SuccessUpdateAlert = jqueryAlert({
                    'content': '修改用户信息成功',
                    'closeTime': 2000,
                });
            }
            CloseDialog();
            //调用 search 的点击事件的两种方法
            $("#search").trigger("click");
            return;
        }, ErrorAlert);
}


function CloseDialog() {
    $('.box #dialogBg').fadeOut(300, function () {
        $('.box #dialog').addClass('bounceOutUp').fadeOut();
    });
}

function SetValue(str, value) {
    $(str).val(value);
    $(str + '_Hidden').val(value);
}
function SetSexValue(str, value) {
    if (value == true) {
        $(str)[1].checked = false;
        $(str)[0].checked = true;
    }
    else if (value == false) {
        $(str)[1].checked = true;
        $(str)[0].checked = false;
    }
    else if (value == null) {
        $(str)[1].checked = false;
        $(str)[0].checked = false;
    }
    $(str + '_Hidden').val(value);
}

function GetRedioValue(str) {
    var value;
    $(str).each(function () {
        if ($(this)[0].checked == true) {
            if ($(this)[0].value == "1") {
                value = true;
            }
            else if ($(this)[0].value == "0") {
                value = false;
            }
            else {
                value = $(this)[0].value;
            }
        }
    });
    return value;
}

function Compare(str) {
    var BeforStr = $(str + '_Hidden').val();
    var AfterStr = $(str).val();
    if (BeforStr == AfterStr) {
        return true;
    }
    else {
        return false;
    }
}

function CompareSex(str) {
    var BeforStr = $(str + '_Hidden').val();
    var AfterStr = GetRedioValue('.box table input[name="sex"]');
    if (BeforStr == AfterStr) {
        return true;
    }
    else {
        return false;
    }
}
