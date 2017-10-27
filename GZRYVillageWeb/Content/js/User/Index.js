/// <reference path="../ajax.js" />
/// <reference path="../../lib/js/alert.js" />
var NotEditAlert;
var PassWordAlert;
var ErrorAlert;
var SuccessAlert;
//修改
function modify(UserId) {
    jQuery.axpost("UserAjax/Get_User_ById", "UserId:'" + UserId + "'", function (data) {
        className = $(this).attr('class');
        $('#dialogBg').fadeIn(300);
        $('#dialog').removeAttr('class').addClass('animated ' + className + '').fadeIn();
        SetValue('.editInfos #UserName', data.Model1.UserName);
        SetValue('.editInfos #UserNickName', data.Model1.UserNickName);
        SetValue('.editInfos #UserPhone', data.Model1.UserPhone);
        SetValue('.editInfos #UserEmail', data.Model1.UserEmail);
        SetImgValue('.editInfos #UserImage', data.Model1.UserImage);
        SetValue('.editInfos #ConsumptionTime', data.Model1.ConsumptionTime);
        $('.editInfos #Modify_User').attr('onclick', 'modifyUserInfo(' + data.Model1.UserId + ')');
        return;
    }, ErrorAlert);
}


function modifyUserInfo(UserId) {
    var UserName = $('.editInfos #UserName').val();
    var UserNickName = $('.editInfos #UserNickName').val();
    var UserPhone = $('.editInfos #UserPhone').val();
    var UserEmail = $('.editInfos #UserEmail').val();
    var UserImage = $('.editInfos #UserImage').attr('src');
    var ConsumptionTime = $('.editInfos #ConsumptionTime').val();
    if (Compare('.editInfos #UserName') && Compare('.editInfos #UserNickName') && Compare('.editInfos #UserPhone') && Compare('.editInfos #UserEmail') && Compare('.editInfos #ConsumptionTime') && CompareImg('.editInfos #UserImage')) {
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
                                          "',UserImage:'" + UserImage +
                                          "',ConsumptionTime:'" + ConsumptionTime + "'"
        , function (data) {
            if (SuccessAlert) {
                SuccessAlert.show();
            }
            else {
                SuccessAlert = jqueryAlert({
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
    $('#dialogBg').fadeOut(300, function () {
        $('#dialog').addClass('bounceOutUp').fadeOut();
    });
}

function SetValue(str, value) {
    $(str).val(value);
    $(str + '_Hidden').val(value);
}

function SetImgValue(str, value) {
    $(str).attr('src',value);
    $(str + '_Hidden').val(value);
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

function CompareImg(str) {
    var BeforStr = $(str + '_Hidden').val();
    var AfterStr = $(str).attr('src');
    if (BeforStr == AfterStr) {
        return true;
    }
    else {
        return false;
    }
}