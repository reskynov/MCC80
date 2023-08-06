// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
let buttonClr = document.querySelector(".btn-change-color");

let buttonText = document.querySelector(".btn-change-text");

let grid1 = document.querySelector(".col-grid1");

let grid2 = document.querySelector(".col-grid2");

let grid3 = document.querySelector(".col-grid3");

buttonClr.addEventListener('click', () => {
    if (grid1.classList.contains("bg-success")) {
        grid1.classList.remove("bg-success")
    } else {
        grid1.classList.add("bg-success")
    }
})

buttonText.addEventListener('click', () => {
    grid2.classList.add("fw-bolder")
})

grid3.addEventListener("mouseover", () => {
    grid3.classList.toggle("bg-success")
})

grid3.addEventListener("mouseleave", () => {
    grid3.classList.toggle("bg-success")
})
