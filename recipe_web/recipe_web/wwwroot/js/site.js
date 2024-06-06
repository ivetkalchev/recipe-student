document.addEventListener("DOMContentLoaded", function () {
    const cookiePopup = document.getElementById("cookie-popup");
    const acceptBtn = document.getElementById("accept-btn");
    const declineBtn = document.getElementById("decline-btn");

    if (document.cookie.includes("cookieAccepted=true")) {
        cookiePopup.style.display = "none";
    } else {
        cookiePopup.style.display = "block";
    }

    acceptBtn.addEventListener("click", function () {
        document.cookie = "cookieAccepted=true; max-age=" + (365 * 24 * 60 * 60) + "; path=/";
        cookiePopup.style.display = "none";
    });

    declineBtn.addEventListener("click", function () {
        cookiePopup.style.display = "none";
    });
});
