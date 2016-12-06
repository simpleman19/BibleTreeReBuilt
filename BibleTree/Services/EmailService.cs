using System.Net;
using System.Net.Mail;
using BibleTree.Models;
using System;

namespace BibleTree.Services {
	public class EmailService {

		public string Contact(BadgeInstance awardedBadge) {
			SQLService db = new SQLService();

			User senduser = db.GetActiveUserById((int)awardedBadge.award_sentid);
			User recieveuser = db.GetActiveUserById((int)awardedBadge.user_id);
			BadgeType badge = db.GetBadgeById((int)awardedBadge.badge_id);

			var body = "<p>You recieved a badge from {0} ({1})</p>" +
				"<p>You recived: {2}<br/>" + 
				"Reson: {3}<br/>" +
				"<img src={4}></p>" +
				"<p>{0} wanted to tell you \"{5}\"</p>";
			var message = new MailMessage();
			message.To.Add(new MailAddress(recieveuser.user_email));
			message.From = new MailAddress(senduser.user_email);
			message.Subject = "You recieved a new badge from " + senduser.user_name + "!";
			message.Body = string.Format(body, senduser.user_name, senduser.user_email, badge.badge_name, badge.badge_description, badge.badge_gifURL, awardedBadge.award_comment);
			message.IsBodyHtml = true;

			try {
				using (var smtp = new SmtpClient()) {
					var credential = new NetworkCredential {
						UserName = "bibletreeproject@gmail.com",    //TESTING ACCOUNT
						Password = "kMbCiz2GsNsU"
					};
					smtp.Credentials = credential;
					smtp.Host = "smtp.gmail.com";
					smtp.Port = 587;
					smtp.EnableSsl = true;

					smtp.Send(message);
				}
			} catch (Exception e) {
				return "<span style='color:red'>fail</span> <br/>[reason:] " + e.Message;
			}
			return "<span style='color:green'>success</span>";
		}
	}
}