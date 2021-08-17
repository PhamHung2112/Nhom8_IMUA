function start() {
  showTime();
  showDate();
}

start();

//time
function showTime() {
  var date = new Date();
  var h = date.getHours(); // 0 - 23
  var m = date.getMinutes(); // 0 - 59
  var s = date.getSeconds(); // 0 - 59
  var session = "SA";

  if (h == 0) {
    h = 12;
  }

  if (h > 12) {
    h = h - 12;
    session = "CH";
  }

  h = h < 10 ? "0" + h : h;
  m = m < 10 ? "0" + m : m;
  s = s < 10 ? "0" + s : s;

  var time = h + ":" + m + ":" + s + " " + session;
  document.getElementById("box__clock").innerText = time;
  document.getElementById("box__clock").textContent = time;

  setTimeout(showTime, 1000);
}

//date
function showDate() {
  let date = new Date();
  let day = date.getDate();
  let month = date.getMonth() + 1;
  let year = date.getFullYear();
  let weekdays = date.toString().split(" ")[0];
  let days;
  switch (weekdays) {
    case "Mon":
      days = "Thứ hai";
      break;
    case "Tue":
      days = "Thứ ba";
      break;
    case "Wed":
      days = "Thứ tư";
      break;
    case "Thu":
      days = "Thứ năm";
      break;
    case "Fri":
      days = "Thứ sáu";
      break;
    case "Sat":
      days = "Thứ bảy";
      break;
    default:
      days = "Chủ nhật";
      break;
  }

  document.getElementById(
    "box__calendar"
  ).innerText = `${days}, Ngày ${checkTime(day)} Tháng ${checkTime(
    month
  )} Năm ${year}`;
}

function checkTime(i) {
  if (i < 10) {
    i = "0" + i;
  }
  return i;
}
