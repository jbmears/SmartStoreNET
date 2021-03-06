namespace SmartStore.Data.Migrations
{
	using System;
	using System.Data.Entity.Migrations;
	using SmartStore.Core.Domain.Topics;
	using SmartStore.Data.Setup;
	using System.Linq;

	public partial class V211 : DbMigration, ILocaleResourcesProvider, IDataSeeder<SmartObjectContext>
    {
        public override void Up()
        {
        }
        
        public override void Down()
        {
        }

		public bool RollbackOnFailure
		{
			get { return false; }
		}

		public void Seed(SmartObjectContext context)
		{
			context.MigrateLocaleResources(MigrateLocaleResources);

			var topic = context.Set<Topic>().FirstOrDefault(x => x.SystemName == "PageNotFound");
			if (topic != null)
			{
				context.Set<Topic>().Remove(topic);
			}
		}

		public void MigrateLocaleResources(LocaleResourcesBuilder builder)
		{
			builder.AddOrUpdate("Admin.Configuration.Settings.GeneralCommon.CanonicalHostNameRule",
				"Canonical host name rule",
				"Regel f�r kanonischen Dom�nennamen");
			builder.AddOrUpdate("Admin.Configuration.Settings.GeneralCommon.CanonicalHostNameRule.Hint",
				"Enforces permanent redirection to a single domain name for a better page rank (e.g. mystore.com > www.mystore.com or vice versa)",
				"Erzwingt die permanente Umleitung zu einem einzelnen Dom�nnennamen f�r ein besseres Seitenranking (z.B. meinshop.de > www.meinshop.de oder umgekehrt)");

			builder.AddOrUpdate("Enums.SmartStore.Core.Domain.Seo.CanonicalHostNameRule.NoRule",
				"Don't apply",
				"Nicht anwenden");
			builder.AddOrUpdate("Enums.SmartStore.Core.Domain.Seo.CanonicalHostNameRule.RequireWww",
				"Require www prefix",
				"www-Pr�fix erzwingen");
			builder.AddOrUpdate("Enums.SmartStore.Core.Domain.Seo.CanonicalHostNameRule.OmitWww",
				"Omit www prefix",
				"www-Pr�fix weglassen");

			builder.AddOrUpdate("Admin.Orders.Fields.PartialRefundOffline",
				"Partial refund (Offline)",
				"Teilerstattung (Offline)");
			builder.AddOrUpdate("Admin.Orders.Fields.Void",
				"Cancel",
				"Stornieren");
			builder.AddOrUpdate("Admin.Orders.Fields.VoidOffline",
				"Cancel (Offline)",
				"Stornieren (Offline)");

			builder.AddOrUpdate("Admin.Orders.Fields.MarkAsPaid.Hint",
				"Sets the payment status to 'paid' without contacting the payment provider.",
				"Setzt den Zahlungsstatus auf 'Bezahlt' ohne dabei den Zahlungsanbieter zu kontaktieren.");
			builder.AddOrUpdate("Admin.Orders.Fields.Capture.Hint",
				"Books a previously authorised payment through the payment provider.",
				"Zieht eine zuvor reservierte Zahlung �ber den Zahlungsanbieter ein.");
			builder.AddOrUpdate("Admin.Orders.Fields.Refund.Hint",
				"Initiates a refund of the total order value at the payment provider.",
				"Leitet eine R�ckerstattung des gesamten Auftragswertes beim Zahlungsanbieter ein.");
			builder.AddOrUpdate("Admin.Orders.Fields.RefundOffline.Hint",
				"Setzt the payment status to 'refunded' without contacting the payment provider.",
				"Setzt den Zahlungsstatus auf 'Erstattet', ohne dabei den Zahlungsanbieter zu kontaktieren.");
			builder.AddOrUpdate("Admin.Orders.Fields.PartialRefund.Hint",
				"Initiates the refund of a partial amount of the total order value at the payment provider.",
				"Leitet die R�ckerstattung eines Teilbetrages des Auftragswertes beim Zahlungsanbieter ein.");
			builder.AddOrUpdate("Admin.Orders.Fields.PartialRefundOffline.Hint",
				"Setzt the payment status to 'partially refunded' including the refunded amount without contacting the payment provider.",
				"Setzt den Zahlungsstatus auf 'Teilweise erstattet' samt Erstattungsbetrag, ohne dabei den Zahlungsanbieter zu kontaktieren.");
			builder.AddOrUpdate("Admin.Orders.Fields.Void.Hint",
				"Initiates the cancellation of the payment transaction at the payment provider.",
				"Leitet die Stornierung der Zahlungstransaktion beim Zahlungsanbieter ein.");
			builder.AddOrUpdate("Admin.Orders.Fields.VoidOffline.Hint",
				"Setzt the payment status to 'canceled' without contacting the payment provider.",
				"Setzt den Zahlungsstatus auf 'Storniert', ohne dabei den Zahlungsanbieter zu kontaktieren.");

			// Error Handling (404/500)
			builder.Delete("PageTitle.PageNotFound");
			builder.AddOrUpdate("ErrorPage.Title",
				"Oops!",
				"Oops!");
			builder.AddOrUpdate("ErrorPage.Body",
				@"We apologize, a server error ocurred while handling your request, this is not a problem with your computer or internet connection.
			The details have been sent to our support team and we will investigate the issue very soon.<br /><br />
			In the meantime, please retry your request as it may have been temporary.",
				@"Leider ist ein Serverfehler aufgetreten, und das hat nichts mit Ihrem Computer oder Ihrem Internetanschluss zu tun.
			Unser Support Team wurde bereits benachrichtigt und wird sich sehr bald um die Behebung k�mmern.");
			builder.AddOrUpdate("NotFoundPage.Title",
				"404",
				"404");
			builder.AddOrUpdate("NotFoundPage.Body",
				"Sorry! The page you were looking for could not be found.",
				"Tut uns leid! Diese Adresse gibt es auf unserer Website nicht.");
		}
    }
}
