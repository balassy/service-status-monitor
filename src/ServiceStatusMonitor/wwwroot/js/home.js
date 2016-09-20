$(document).ready(function () {
	$('body').css('display', 'none');
	$('body').fadeIn(1000);

	var initialResult = {
		dev: {
			frontend: {
				text: 'Updating...',
				isRunning: true
			},
			backend: {
				text: 'Updating...',
				isRunning: true
			}
		},
		stage: {
			frontend: {
				text: 'Updating...',
				isRunning: true
			},
			backend: {
				text: 'Updating...',
				isRunning: true
			}
		},
		lastUpdatedAt: 'Updating now...'
	};
	
	var viewModel = {
		result: ko.observable(initialResult),
		lastUpdatedAt: ko.observable('')
	}
	ko.applyBindings(viewModel);

	setInterval(function () {
		checkEndpoints();
	}, 60000);

	checkEndpoints();

	function checkEndpoints() {
		$.ajax({
			url: '/Home/Status',
			cache: false,
			success: function (data) {
				displayResult(data);
				displayTimestamp('Last updated at ' + getTimeStamp());
			},
			error: function (xhr, textStatus, errorThrown) {
				displayResult(initialResult);
				displayTimestamp("Ajax error: " + textStatus + ". Details: " + errorThrown + " (HTTP " + xhr.status + ").");
			}
		});

	}

	function displayResult(result) {
		viewModel.result(result);
	}

	function displayTimestamp(timestamp) {
		viewModel.lastUpdatedAt(timestamp);
	}

	function getTimeStamp() {
		return new Date().toTimeString().replace(/.*(\d{2}:\d{2}:\d{2}).*/, "$1");
	}
});