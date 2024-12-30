const $ = document.querySelector.bind(document);

$("#not-btn").addEventListener("click", () => {
  $("#not-btn").style.display = "none";
});

$("#btn").addEventListener("click", () => {
  $("#not-btn").style.display = "inline-block";
});

$("#bg-btn").addEventListener("click", () => {
  const randomColor = Math.floor(Math.random() * 16777215).toString(16);
  const contrastColor =
    parseInt(randomColor, 16) > 0xffffff / 2 ? "black" : "white";
  document.body.style.backgroundColor = "#" + randomColor;
  document.body.style.color = contrastColor;
});
