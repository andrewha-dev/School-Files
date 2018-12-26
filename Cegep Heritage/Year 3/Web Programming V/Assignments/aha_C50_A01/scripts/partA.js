//GLOBAL VARIABLE FOR INDEXING OF WORK RECORD
var WORK_RECORD_INDEX = 0;
var WORK_RECORD_SIZE = 0;
$(document).ready(function() {

    $("#main").hide();
    disableButtons();
    //Making a $.Get request to the clients.xml file
    $.get('PartA/clients.xml')
        .success(function(data) {
            //Getting the data, sorting it and adding it the dropdown
            $(data).find('client').sort(function(a, b) {
                return sortLetter($(a).find('clientName').text(), $(b).find('clientName').text())
            }).each(function(key, value) {
                addSelection(value)
            });
        })
        .error(function(e) {
            console.log('Unable To Load File: ' + e);
        });

        $('.form-control').on('change', function(e){
          enableButtons();
          $("#main").fadeIn();
          WORK_RECORD_INDEX = 0;
          WORK_RECORD_SIZE = 0;
          getInvoice($('.form-control').val());
        })

        $('.btnPrevious').on('click', function(){
          if (WORK_RECORD_INDEX == 0)
            WORK_RECORD_INDEX = WORK_RECORD_SIZE - 1;
          else
          WORK_RECORD_INDEX--;
          //Afterwards grabs the invoice
          getInvoice($('.form-control').val());
        })

        $('.btnNext').on('click', function(){
          if (WORK_RECORD_INDEX == WORK_RECORD_SIZE - 1)
            WORK_RECORD_INDEX = 0;
          else
          WORK_RECORD_INDEX++;
          getInvoice($('.form-control').val());
        })

        $('.btnSearch').on('click', function(){
          let searchTerm = "";
          searchTerm = $('#txtSearch').val();
          getInvoiceSearch($('.form-control').val(), searchTerm)
        })

});


var addSelection = (_client) => {
  //Adding the options
  $('.form-control').append(
      $('<option>', {
          value: ($(_client).find('invoice').text()),
          text: ($(_client).find('clientName').text())
      })
  );
}

var sortLetter = (a, b) => {
    let firstName = a.toLowerCase();
    let secondName = b.toLowerCase();
    let res = (a < b ? -1 : 1);
    return res;
}

var getInvoice = (invoiceFile) => {
  //Making a get request to get the specific invoice
  $.get('PartA/' + invoiceFile)
      .success(function(data) {
          //Clear the div
          $('.clientDisplay').html('');
          //Reappend the data
          getClientInfo($(data).find('invoice').find('client')[0]);
          getInvoiceInfo($(data).find('invoice').find('info')[0]);

          //Getting the work records and sorting them
          getWorkRecords($(data).find('workRecord').sort(function(a, b){
            return (parseInt($(a).attr('workNumber')) - parseInt($(b).attr('workNumber')));
          }), WORK_RECORD_INDEX);
      })
      .error(function(e) {
          console.log('Unable To Load Invoice File: ' + e);
      });
}

var getInvoiceInfo = (invoiceInfo) => {
  let invoiceInfoHTML = "";
  let invoiceNum = $(invoiceInfo).attr('invoiceNumber');
  invoiceInfoHTML += "<p>Invoice: " + invoiceNum + "</p>";
  let date = $(invoiceInfo).find('invoiceDate').text();
  invoiceInfoHTML += "<p>Date: " + date + "</p>";

  let billRate = $(invoiceInfo).find('billRate').text();
  invoiceInfoHTML += "<p>Bill Rate: " + billRate + "</p>";
  $('.clientDisplay').append(invoiceInfoHTML);
}

var getClientInfo = (clientInfo) => {
  let clientInfoHTML = "<h3>Client Info:</h3>";
  let fullName = $(clientInfo).find('contactFirstName').text() + " " + $(clientInfo).find('contactLastName').text();
  clientInfoHTML += '<p>Contact: ' + fullName + '</p>';
  let street = $(clientInfo).find('clientStreet').text();
  clientInfoHTML += '<p>'+ street + '</p>';
  let provCity = $(clientInfo).find('clientCity').text() + " " + $(clientInfo).find('clientProvince').text();
  clientInfoHTML += '<p>'+ provCity + '</p>';
  let postalCode = $(clientInfo).find('clientPostalCode').text();
  clientInfoHTML += '<p>'+ postalCode + '</p>';
  //Checking to see if there is a discount
  let discount = $(clientInfo).find('clientDiscount').text();
  if  (discount != (null || ""))
  {
    clientInfoHTML += '<p>Discount: ' + (discount * 100) + '% '+ '</p>';
  }



  $('.clientDisplay').append(clientInfoHTML);
}

var getWorkRecords = (workRecords, index) => {
  //SETTING THE WORKRECORD ARRAY SIZE
  WORK_RECORD_SIZE = workRecords.length;
  let workRecord  = workRecords[index];
  let workRecordInfo = "<h3>Work Record:</h3>";
  let workNumber = $(workRecord).attr('workNumber');
  workRecordInfo += "<p>Work Number: " + workNumber + "</p>";
  let desc = $(workRecord).find('workDescription').text();
  workRecordInfo += "<p>Description: " + desc + "</p>";
  let date = $(workRecord).find('workDate').text();
  workRecordInfo += "<p>Date:" + date + "</p>";
  let workType = $(workRecord).find('workTypeNumber').text();
  workRecordInfo += "<p>Work Type: " + workType + "</p>";
  let hours = $(workRecord).find('billedHours').text();
  workRecordInfo += "<p>Billed Hours: " + hours + "</p>";
  $('.workRecordDisplay').html(workRecordInfo);
}

var getInvoiceSearch = (invoiceFile, input) => {
  //Making a get request to get the specific invoice
  $.get('PartA/' + invoiceFile)
      .success(function(data) {
          //Clear the div
          $('.clientDisplay').html('');
          //Reappend the data
          getClientInfo($(data).find('invoice').find('client')[0]);
          getInvoiceInfo($(data).find('invoice').find('info')[0]);

          if (searchWorkRecords($(data).find('workRecord').sort(function(a, b){
            return (parseInt($(a).attr('workNumber')) - parseInt($(b).attr('workNumber')));
          }), input)){
            //Getting the work records and sorting them
            getWorkRecords($(data).find('workRecord').sort(function(a, b){
              return (parseInt($(a).attr('workNumber')) - parseInt($(b).attr('workNumber')));
            }), WORK_RECORD_INDEX);
            $('.btnPrevious').attr('disabled', false);
            $('.btnNext').attr('disabled', false);
          }
          else {
            console.log("No matches");
            displayNoMatch();
          }

      })
      .error(function(e) {
          console.log('Unable To Load Invoice File: ' + e);
      });
}

var searchWorkRecords =(data, input) =>{
  let match = false;
  if (!errorCheck(input))
  {
  $(data).each(function(index, el) {
    if ($(el).attr('workNumber') == input)
    {
      WORK_RECORD_INDEX = index;
      match = true;
    }
  });
}
  return match;
}

var disableButtons = () => {
  $('.btnSearch').attr('disabled', true);
}

var enableButtons = () => {
  $('.btnPrevious').attr('disabled', false);
  $('.btnNext').attr('disabled', false);
  $('.btnSearch').attr('disabled', false);
}

var errorCheck = (input) => {
  let isValid = false;
  if (input === "")
    isValid = true;
  if (!$.isNumeric(input))
    isValid = true;
  return isValid;
}

var displayNoMatch = () => {
  $('.workRecordDisplay').html('');
  $('.workRecordDisplay').append('<h3>Work Record:<h3>');
  $('.workRecordDisplay').append('<p>No records found</p>');
  $('.workRecordDisplay').append('<a id="clear" href="#">Clear Search</a><br>');
  $('.btnPrevious').attr('disabled', true);
  $('.btnNext').attr('disabled', true);
  $("#clear").off();
  $('#clear').on('click', function(){
    WORK_RECORD_INDEX = 0;
    getInvoice($('.form-control').val());
    $('.btnPrevious').attr('disabled', false);
    $('.btnNext').attr('disabled', false);
  })

}
