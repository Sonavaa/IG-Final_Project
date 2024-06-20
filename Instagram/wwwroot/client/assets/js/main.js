"use strict";
const body = document.querySelector("body");

const more_row = document.querySelector(".more");
const menu_Modal = document.querySelector(".menuModal");

const switch_accounts_btn = document.querySelector("#switch-accounts");
const switch_accounts = document.querySelector(".switchModal");

const create_input = document.querySelector("#create-input");
const create_btn = document.querySelector(".create-row");
const create_new_post_modal = document.querySelector(".create-new-post-Modal");

const post_view_on_modal = document.querySelector("#post-file");
const edit_post_Modal = document.querySelector(".edit-post-Modal");
const done_text = document.querySelector(".edit-post-Modal #done-text");
const create_post_Modal = document.querySelector(".create-post-modal");
const share_text = document.querySelector(".create-post-Modal #share-text");
const edit_post_modal = document.querySelector(".edit-post-modal");
const edit_modal_done_btn = document.querySelector(".done-text");

const notfications_Modal = document.querySelector(".notfications-Modal");
const notfications_btn = document.querySelector(".notfications");

const search_Modal = document.querySelector(".searchModal");
const search_btn = document.querySelector(".search");
const search_input = document.querySelector("#input-searchbar");
const search_input_x = document.querySelector(".searchBar .input-x");
const search_info_x = document.querySelectorAll(".searched-account .info-x");
const searched_account = document.querySelector(".searched-account");
const searched_accounts = document.querySelector(".searched-accounts");
const search_clear_all = document.querySelector("#clear_all");

const post_ellipsis_dots = document.querySelectorAll(".ellipsis .fa-ellipsis");

const post_like_heart = document.querySelector(".post-like");


const detail_page_bookmark = document.querySelector(".detail-bookmark");

const view_comments = document.querySelector("#view-comments");
const add_comment = document.querySelector("#add-comment");

let post_caption = document.querySelector("#caption");
const post_more_span = document.querySelector("#caption .more_s");
const post_less_span = document.querySelector(".less_s");

const smile = document.querySelector(".fa-face-smile");
const more_span = document.querySelector("#more-span");
const less_span = document.querySelector("#less-span");
const userName_in_comment = document.querySelector("#userName");
let comment_text = document.querySelector("#comment-cmt");
const delete_Modal = document.querySelector(".delete-cancel");
const cancel_btn = document.querySelector(".delete-cancel p");
const comment_view = document.querySelector(".comment-view");
const ellipsis_btn = document.querySelector(".cmt .fa-ellipsis");
const follow_following = document.querySelector("#follow-or-following");
const heart_icon_for_like = document.querySelector(".comment-like");
const post = document.querySelector(".detail-post-view-side");
const post_detail = document.querySelector(".post-comment-detail-Modal");

const switch_in_suggestion = document.querySelector("#switch");

const switch_appearance_row_more_modal = document.querySelector("#switch-appearance")
const switch_appearance_btn = document.querySelector(".mood")
const switch_appearance_modal = document.querySelector(".appearance-change")
let isOpen = false;

less_span.addEventListener("click", function () {
    comment_text.innerText = subString;
    if ((comment_text.innerText = subString)) {
        more_span.style.display = "block";
        less_span.style.display = "none";
        cmt.style.width = '40% !important'

        console.log(cmt.style.width)
    } else {
        less_span.style.display = "none";
        comment_text.innerText = subString;
        more_span.style.display = "block";
        cmt.style.width = '100% !important'
        // console.log(comment_text.style.width)

    }
});


less_span.addEventListener("click", function () {
    comment_text.innerText = subString;
    if ((comment_text.innerText = subString)) {
        more_span.style.display = "block";
        less_span.style.display = "none";
        //cmt.style.width = '40% !important'
        //console.log(cmt.style.width)
    } else {
        less_span.style.display = "none";
        comment_text.innerText = subString;
        more_span.style.display = "block";
        cmt.style.width = '100% !important'
        // console.log(comment_text.style.width)

    }
});


switch_appearance_row_more_modal.addEventListener("click", function () {
    switch_appearance_modal.style.display = "block";
    menu_Modal.style.display = "none";
});


if (view_comments != undefined) {

    view_comments.addEventListener("click", () => {
        post_detail.style.display = "flex";
        body.style.overflow = "hidden";
        isOpen = true;
    });

}

if (add_comment != undefined) {

    add_comment.addEventListener("click", () => {
        post_detail.style.display = "flex";
        body.style.overflow = "hidden";
        isOpen = true;
    });
}

window.addEventListener("click", function (event) {
    if (isOpen && !post_detail.contains(event.target) && !post_bottom_comment_icon.contains(event.target) && !view_comments.contains(event.target) && !add_comment.contains(event.target)) {
        post_detail.style.display = "none";
        body.style.overflow = "auto";
        isOpen = false;
    }
});

document.addEventListener("DOMContentLoaded", () => {
    const posts = document.querySelectorAll(".post");

    posts.forEach(post => {
        const bookmark = post.querySelector(".bookmark");
        bookmark.addEventListener("click", function () {
            if (bookmark.classList.contains("fa-regular")) {
                bookmark.classList.remove("fa-regular");
                bookmark.classList.add("fa-solid");
                bookmark.style.color = "white";
            } else {
                bookmark.classList.remove("fa-solid");
                bookmark.classList.add("fa-regular");
                bookmark.style.color = "white";
            }
        });

        const mini_like_heart = post.querySelector(".comment-view .mini-heart");
        mini_like_heart.addEventListener("click", function () {
            if (mini_like_heart.classList.contains("fa-regular")) {
                mini_like_heart.classList.remove("fa-regular");
                mini_like_heart.classList.add("fa-solid");
                mini_like_heart.style.color = "red";
            } else {
                mini_like_heart.classList.remove("fa-solid");
                mini_like_heart.classList.add("fa-regular");
                mini_like_heart.style.color = "white";
            }
        });

        const post_img = post.querySelector(".post #post");
        post_img.addEventListener("dblclick", function () {
            post_like_heart.style.display = "block";
            post_like_bottom_heart.classList.add("fa-regular");

            if (post_like_bottom_heart.classList.contains("fa-regular")) {
                post_like_bottom_heart.classList.remove("fa-regular");
                post_like_bottom_heart.classList.add("fa-solid");
                post_like_bottom_heart.style.color = "red";
            }
            setTimeout(function () {
                post_like_heart.style.display = "none";
            }, 1500);
        })


        const post_like_bottom_heart = post.querySelector(".post .bottom-side .left .fa-regular");
        if (post_like_bottom_heart != undefined) {
            post_like_bottom_heart.addEventListener("click", function () {
                if (post_like_bottom_heart.classList.contains("fa-regular")) {
                    post_like_bottom_heart.classList.remove("fa-regular");
                    post_like_bottom_heart.classList.add("fa-solid");
                    post_like_bottom_heart.style.color = "red";
                } else {
                    post_like_bottom_heart.classList.remove("fa-solid");
                    post_like_bottom_heart.classList.add("fa-regular");
                    post_like_bottom_heart.style.color = "white";
                }
            });
        }

        const post_bottom_comment_icon = post.querySelector("#post-bottom-comment-icon");
        post_bottom_comment_icon.addEventListener("click", () => {
            post_detail.style.display = "flex";
            post_detail.style.position = "fixed";
            isOpen = true;
            body.style.overflow = "hidden";
        });

    });
});


detail_page_bookmark.addEventListener("click", function () {
    if (detail_page_bookmark.classList.contains("fa-regular")) {
        detail_page_bookmark.classList.remove("fa-regular");
        detail_page_bookmark.classList.add("fa-solid");
        detail_page_bookmark.style.color = "white";
    } else {
        detail_page_bookmark.classList.remove("fa-solid");
        detail_page_bookmark.classList.add("fa-regular");
        detail_page_bookmark.style.color = "white";
    }
});

more_row.addEventListener("click", function (e) {
    e.preventDefault();
    if (switch_appearance_modal.style.display == "block") {
        switch_appearance_modal.style.display = "none";
    }

    if (menu_Modal.classList.contains("hidden")) {
        menu_Modal.style.display = "block";
        menu_Modal.classList.remove("hidden");
    } else {
        menu_Modal.style.display = "none";
        menu_Modal.classList.remove("block");
        menu_Modal.classList.add("hidden");
    }
});

switch_accounts_btn.addEventListener("click", function (e) {
    e.preventDefault();
    if (switch_accounts.classList.contains("hidden")) {
        switch_accounts.style.display = "block";
        switch_accounts.classList.remove("hidden");
        menu_Modal.style.display = "none";
        menu_Modal.classList.remove("block");
        menu_Modal.classList.add("hidden");
        body.style.overflow = "hidden";
    } else {
        switch_accounts.style.display = "none";
        switch_accounts.classList.remove("block");
        switch_accounts.classList.add("hidden");
    }
});

if (switch_in_suggestion != undefined) {
    switch_in_suggestion.addEventListener("click", function (e) {
        e.preventDefault();
        if (switch_accounts.classList.contains("hidden")) {
            switch_accounts.style.display = "block";
            switch_accounts.classList.remove("hidden");
            menu_Modal.style.display = "none";
            menu_Modal.classList.remove("block");
            menu_Modal.classList.add("hidden");
            body.style.overflow = "hidden";
        } else {
            switch_accounts.style.display = "none";
            switch_accounts.classList.remove("block");
            switch_accounts.classList.add("hidden");
        }
    });
}

window.addEventListener("click", function (event) {
    if (event.target == switch_accounts) {
        switch_accounts.style.display = "none";
        switch_accounts.classList.remove("block");
        switch_accounts.classList.add("hidden");
    }
});


create_btn.addEventListener("click", (e) => {
    e.preventDefault();
    create_input.click();
    console.log("create_btn");
});

if (create_input != undefined) {
    create_input.addEventListener("change", function () {
        const selectedFile = this.files[0];
        console.log("Selected File Name: ", selectedFile.name);
        console.log("Selected File Size: ", selectedFile.size, " bytes");

        sessionStorage.setItem('postView', selectedFile.name);

        localStorage.setItem("postView", selectedFile.name);
        localStorage.setItem("postViewRoute", selectedFile.mozFullPath);

        const json = JSON.stringify(selectedFile)


        const hiddenInput = document.querySelector('.hiddenInput')
        const hiddenInput2 = document.querySelector('.hiddenInput2')
        const hiddenInput3 = document.querySelector('.hiddenInput3')
        hiddenInput.value = create_input.value
        if (hiddenInput2 != undefined)
            hiddenInput2.value = create_input.value

        localStorage.setItem('photo', json)
        if (selectedFile.name != null) {

            var file = this.files[0];
            if (file) {
                var reader = new FileReader();

                reader.onload = function (e) {
                    post_view_on_modal.src = e.target.result;
                    hiddenInput3.value = e.target.result;
                    create_post_Modal.style.display = "block";
                };

                reader.readAsDataURL(file);
            } else {
                alert("Lütfen bir dosya seçin.");
            }

            console.log(`New File Src: ${post_view_on_modal.src}`)
        } else {
            menu_Modal.style.display = "none";
        }
    });
}
document.addEventListener("DOMContentLoaded", () => {
    const posts = document.querySelectorAll(".post");

    posts.forEach((post) => {
        const postEllipsisDot = post.querySelector(".ellipsis");
        const dotsModal = post.querySelector(".dots");
        const myPostDotsModal = post.querySelector(".myPost-dots");
        const dotsCancelBtn = post.querySelector("#dots-cancel");
        const myPostCancelBtn = post.querySelector("#myPost-cancel");

        // Ellipsis butonuna t?kland???nda ilgili modal aç?l?r
        postEllipsisDot.addEventListener("click", () => {
            // Tüm modallar? kapat
            const allModals = document.querySelectorAll(".dots, .myPost-dots");
            allModals.forEach((modal) => {
                modal.style.display = "none";
            });

            // Sadece t?klanan ellipsis'e ait modal aç
            if (dotsModal) {
                dotsModal.style.display = "flex";
                dotsModal.style.top = `${post.offsetHeight / 2}px`;
                dotsModal.style.left = `${post.offsetWidth / 2}px`;
            }

            // E?er myPost-dots modal varsa ve postEllipsisDot'a t?klan?rsa
            if (myPostDotsModal) {
                myPostDotsModal.style.display = "flex";
                myPostDotsModal.style.top = `${post.offsetHeight / 2}px`;
                myPostDotsModal.style.left = `${post.offsetWidth / 2}px`;
            }
        });

        // Cancel butonuna t?kland???nda ilgili modal kapan?r
        if (dotsCancelBtn) {
            dotsCancelBtn.addEventListener("click", () => {
                if (dotsModal) {
                    dotsModal.style.display = "none";
                }
            });
        }

        // MyPost Cancel butonuna t?kland???nda ilgili modal kapan?r
        if (myPostCancelBtn) {
            myPostCancelBtn.addEventListener("click", () => {
                if (myPostDotsModal) {
                    myPostDotsModal.style.display = "none";
                }
            });
        }
    });
});



notfications_btn.addEventListener("click", function (e) {
    e.preventDefault();
    if (notfications_Modal.style.display == "none") {
        notfications_Modal.style.display = "block";
        console.log("notfications");
    } else {
        notfications_Modal.style.display = "none";
    }
});

search_btn.addEventListener("click", function (e) {
    e.preventDefault();
    if (search_Modal.style.display == "none") {
        search_Modal.style.display = "block";
        console.log("notfications");
    } else {
        search_Modal.style.display = "none";
    }
});

window.addEventListener("click", function (event) {
    if (event.target == search_Modal) {
        search_Modal.style.display = "none";
    }
});

search_info_x.forEach((button) => {
    button.addEventListener("click", function () {
        const accountDiv = button.parentElement;
        accountDiv.style.display = "none";
    });
});

search_clear_all.addEventListener("click", function () {
    searched_accounts.style.display = "none";
});

$(function () {
    // Initializes and creates emoji set from sprite sheet
    window.emojiPicker = new EmojiPicker({
        emojiable_selector: '[data-emojiable=true]',
        assetsPath: '../client/assets/lib/img/',
        popupButtonClasses: 'fa fa-smile-o'
    });
    // Finds all elements with `emojiable_selector` and converts them to rich emoji input fields
    // You may want to delay this step if you have dynamically created input fields that appear later in the loading process
    // It can be called as many times as necessary; previously converted input fields will not be converted again
    window.emojiPicker.discover();
});

let subString = comment_text.innerText.substring(0, 50);
const original_commit_text = comment_text.innerText;
comment_text.innerText = subString;

more_span.addEventListener("click", function () {
    comment_text.innerText = original_commit_text;
    if ((comment_text.innerText = original_commit_text)) {
        more_span.style.display = "none";
        less_span.style.display = "block";
    } else {
        less_span.style.display = "none";
        more_span.style.display = "block";
    }
});

less_span.addEventListener("click", function () {
    comment_text.innerText = subString;
    if ((comment_text.innerText = subString)) {
        more_span.style.display = "block";
        less_span.style.display = "none";
    } else {
        less_span.style.display = "none";
        comment_text.innerText = subString;
        more_span.style.display = "block";
    }
});

ellipsis_btn.addEventListener("click", function () {
    delete_Modal.style.display = "flex";
});

cancel_btn.addEventListener("click", function () {
    delete_Modal.style.display = "none";
});

follow_following.addEventListener("click", function () {
    if (follow_following.innerText == "Follow") {
        follow_following.innerText = "Following";
    } else {
        follow_following.innerText = "Follow";
    }
});



if (post_view_on_modal != undefined) {
    post_view_on_modal.addEventListener("dblclick", function () {

        heart_icon_for_like.addEventListener("click", (e) => {
            e.preventDefault();
            heart_icon_for_like.click();
          
        });

        heart_icon_for_like.addEventListener("click", function () {
            if (heart_icon_for_like.classList.contains("fa-regular")) {
                heart_icon_for_like.classList.remove("fa-regular");
                heart_icon_for_like.classList.add("fa-solid");
                heart_icon_for_like.style.color = "red";
            } else {
                heart_icon_for_like.classList.remove("fa-solid");
                heart_icon_for_like.classList.add("fa-regular");
                heart_icon_for_like.style.color = "white";
            }
        });

        if (heart_icon_for_like.classList.contains("fa-regular")) {
            heart_icon_for_like.classList.remove("fa-regular");
            heart_icon_for_like.classList.add("fa-solid");
            heart_icon_for_like.style.color = "red";
        } else {
            heart_icon_for_like.classList.remove("fa-solid");
            heart_icon_for_like.classList.add("fa-regular");
            heart_icon_for_like.style.color = "white";
            console.log("nads");
        }
    });
}


let clickCount = 0;
const label = document.getElementById('switch-mood');
const mood_situation_text = document.getElementById('mood-situation-text');
const static_top = document.querySelector('.static-top');


if (label != undefined) {
    label.addEventListener('click', (e) => {
        clickCount++;
        if (clickCount % 2 === 0) {
            mood_situation_text.innerHTML = 'Dark Mode';
            static_top.innerHTML = `
            <i class="fa-solid fa-chevron-left"></i>
            <span>Switch appearance</span>
            <i class="fa-regular fa-moon"></i>
        `;

        }
        else {
            mood_situation_text.innerHTML = 'Light Mode';
            static_top.innerHTML = `
            <i class="fa-solid fa-chevron-left"></i>
            <span>Switch appearance</span>
            <i class="fa-regular fa-sun"></i>
        `;
        }
    });
}

document.addEventListener('DOMContentLoaded', function () {
    const moodSituationText = document.getElementById('mood-situation-text');
    const switchMood = document.getElementById('switch-mood');

    function updateMode() {
        if (switchMood.checked) {
            body.style.backgroundColor = "#FFF";
            document.querySelector("a").style.backgroundColor = "#000";
            body.style.color = "#000";
            moodSituationText.textContent = 'Light Mode';
        } else {
            body.style.backgroundColor = "#000";
            body.style.color = "#FFF";
            moodSituationText.textContent = 'Dark Mode';
        }
    }

    // Initialize the mode based on the checkbox state
    updateMode();

    // Add event listener to toggle the mode
    switchMood.addEventListener('change', updateMode);
});

$('.like').on('click', function () {
    $(this).toggleClass('fa-regular fa-solid');
    if ($(this).hasClass('fa-solid')) {
        $(this).addClass('activeForLike');
    } else {
        $(this).removeClass('activeForLike');
    }
});