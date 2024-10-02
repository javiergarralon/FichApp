function currentTime() {
    let date = new Date()
    let hh = date.getHours();
    let mm = date.getMinutes();
    let ss = date.getSeconds();

    hh = (hh < 10) ? "0" + hh : hh;
    mm = (mm < 10) ? "0" + mm : mm;
    ss = (ss < 10) ? "0" + ss : ss;

    let time = hh + ":" + mm + ":" + ss;

    let watch = document.querySelector('#digital');
    watch.innerHTML = time;

    let hhRotation = ((hh % 12) * 180) / 6;
    let mmRotation = ((mm * 180) / 30);
    let ssRotation = (ss * 180) / 30;

    document.querySelector('#hours').style.transform = "rotate(" + hhRotation + "deg)";
    document.querySelector('#minutes').style.transform = "rotate(" + mmRotation + "deg)";
    document.querySelector('#seconds').style.transform = "rotate(" + ssRotation + "deg)";
}

function calculateTimeSpent(checkin, timeSpent) {
    let currentTime = new Date();  // Current DateTime (DateTime.Now equivalent)

    // Parse the incoming checkin and timeSpent
    let checkinDate = new Date(checkin);
    let [hours, minutes, seconds] = timeSpent.split(':').map(Number);

    // Add timeSpent to checkin
    currentTime.setHours(currentTime.getHours() + hours);
    currentTime.setMinutes(currentTime.getMinutes() + minutes);
    currentTime.setSeconds(currentTime.getSeconds() + seconds);

    // Calculate the difference in milliseconds
    let diff = currentTime - checkinDate;

    // Convert the difference into hours, minutes, and seconds
    let diffSeconds = Math.floor((diff / 1000) % 60);
    let diffMinutes = Math.floor((diff / 1000 / 60) % 60);
    let diffHours = Math.floor((diff / 1000 / 60 / 60) % 24);

    // Format with leading zeros
    diffHours = (diffHours < 10) ? "0" + diffHours : diffHours;
    diffMinutes = (diffMinutes < 10) ? "0" + diffMinutes : diffMinutes;
    diffSeconds = (diffSeconds < 10) ? "0" + diffSeconds : diffSeconds;

    let formattedTime = diffHours + ":" + diffMinutes + ":" + diffSeconds;
    let watchElement = document.querySelector('#timeSpentWatch');
    watchElement.innerHTML = formattedTime;
    console.log('currenttime: ' + currentTime + 'checkin: ' + checkin + '\ntimespent: ' + timeSpent + '\nchekindate: ' + checkinDate + '\nformattedTime: ' + formattedTime + '\diff: ' + diff);

    // Set threshold times (08:30:00 for weekdays, 07:00:00 for Fridays)
    let normalThreshold = { hours: 8, minutes: 30, seconds: 0 };
    let fridayThreshold = { hours: 7, minutes: 0, seconds: 0 };

    let today = new Date();
    let isFriday = today.getDay() === 5;  // 5 represents Friday

    let threshold = isFriday ? fridayThreshold : normalThreshold;

    // Check if the elapsed time is below or above the threshold
    if (diffHours < threshold.hours ||
        (diffHours === threshold.hours && diffMinutes < threshold.minutes) ||
        (diffHours === threshold.hours && diffMinutes === threshold.minutes && diffSeconds < threshold.seconds)) {

        // If time is below threshold, set class to text-danger
        watchElement.className = 'text-center text-danger';
    } else {
        // If time meets or exceeds the threshold, set class to text-success
        watchElement.className = 'text-center text-success';
    }
}

setInterval(currentTime, 1000);
setInterval(function () {
    if (checkin !== "" && checkout == "") {
        calculateTimeSpent(checkin, timeSpent);
    }
}, 1000);