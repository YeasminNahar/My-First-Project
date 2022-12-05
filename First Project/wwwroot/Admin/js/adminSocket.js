let notificationTone = document.getElementById('clientRegistered');

//event catchers
//socket declared on js.blade.php file
socket.on('account-registered', accountRegistered);
socket.on('course-purchased', coursePurchased);
socket.on('notification', notification);

function accountRegistered(data){
    Dashmix.helpers('notify', {type: 'success', icon: 'fa fa-check mr-1', message: data});
    notificationTone.play();
}

function coursePurchased(data) {
    Dashmix.helpers('notify', {type: 'success', icon: 'fa fa-check mr-1', message: data});
    notificationTone.play();
}

/**
 * general notification
 * @param data
 */
function notification(data) {
    Dashmix.helpers('notify', {type: 'info', icon: 'fa fa-check mr-1', message: data});
    notificationTone.play();

    if(vmNotification.notifications !== undefined){
        if(vmNotification.notifications.current_page == 1){
            vmNotification.getNotifications();
        }
    }else{
        console.log('vm not found')
    }

}
