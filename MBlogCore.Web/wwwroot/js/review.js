document.addEventListener("DOMContentLoaded", () => {
    getReview();
});

let reviewButton = document.getElementById("confirm-but");

reviewButton.addEventListener("click", function (ev) {
    let message = document.getElementById("review-mes");
    if (message) {

    }
});



function getReview() {
    let id = document.getElementById("movie-key").value;
    fetch("/review?Id=" + id).then(resposne => response.json()).then((data) =>
        console.log(data)
    );
}