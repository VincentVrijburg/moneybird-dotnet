using System.Text.Json.Serialization;

namespace Moneybird.Net.Entities.Notes
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum NoteTodoType
    {
        [JsonStringEnumMemberName("sales_invoice_due")]
        SalesInvoiceDue,

        [JsonStringEnumMemberName("purchase_invoice_due")]
        PurchaseInvoiceDue,

        [JsonStringEnumMemberName("general_document_reminder")]
        GeneralDocumentReminder,

        [JsonStringEnumMemberName("general_document_due")]
        GeneralDocumentDue,

        [JsonStringEnumMemberName("new_document_awaiting_processing")]
        NewDocumentAwaitingProcessing,

        [JsonStringEnumMemberName("new_financial_mutation_awaiting_processing")]
        NewFinancialMutationAwaitingProcessing,

        [JsonStringEnumMemberName("financial_mutations_not_updated")]
        FinancialMutationsNotUpdated,

        [JsonStringEnumMemberName("sales_invoice_payment_not_linked_to_financial_mutation")]
        SalesInvoicePaymentNotLinkedToFinancialMutation,

        [JsonStringEnumMemberName("document_payment_not_linked_to_financial_mutation")]
        DocumentPaymentNotLinkedToFinancialMutation,

        [JsonStringEnumMemberName("sales_invoice_awaiting_payment_batch")]
        SalesInvoiceAwaitingPaymentBatch,

        [JsonStringEnumMemberName("export_sales_invoices_ready")]
        ExportSalesInvoicesReady,

        [JsonStringEnumMemberName("export_documents_ready")]
        ExportDocumentsReady,

        [JsonStringEnumMemberName("export_contacts_ready")]
        ExportContactsReady,

        [JsonStringEnumMemberName("import_contacts_ready")]
        ImportContactsReady,

        [JsonStringEnumMemberName("recurring_sales_invoice_auto_send_failed")]
        RecurringSalesInvoiceAutoSendFailed,

        [JsonStringEnumMemberName("sales_invoice_scheduled_sending_failed")]
        SalesInvoiceScheduledSendingFailed,

        [JsonStringEnumMemberName("sales_invoice_reminder_sending_failed")]
        SalesInvoiceReminderSendingFailed,

        [JsonStringEnumMemberName("sales_invoice_becoming_due")]
        SalesInvoiceBecomingDue,

        [JsonStringEnumMemberName("sales_invoice_collecting_failed")]
        SalesInvoiceCollectingFailed,

        [JsonStringEnumMemberName("estimate_due")]
        EstimateDue,

        [JsonStringEnumMemberName("export_estimates_ready")]
        ExportEstimatesReady,

        [JsonStringEnumMemberName("sales_invoice_email_delivery_failed")]
        SalesInvoiceEmailDeliveryFailed,

        [JsonStringEnumMemberName("sales_invoice_email_marked_as_spam")]
        SalesInvoiceEmailMarkedAsSpam,

        [JsonStringEnumMemberName("estimate_email_delivery_failed")]
        EstimateEmailDeliveryFailed,

        [JsonStringEnumMemberName("estimate_email_marked_as_spam")]
        EstimateEmailMarkedAsSpam,

        [JsonStringEnumMemberName("purchase_invoice_invalid_ubl")]
        PurchaseInvoiceInvalidUbl,

        [JsonStringEnumMemberName("sales_invoice_unprintable")]
        SalesInvoiceUnprintable,

        [JsonStringEnumMemberName("estimate_unprintable")]
        EstimateUnprintable,

        [JsonStringEnumMemberName("auditfile_ready")]
        AuditfileReady,

        [JsonStringEnumMemberName("import_financial_statement_finished")]
        ImportFinancialStatementFinished,

        [JsonStringEnumMemberName("recurring_sales_invoice_auto_send_skipped_import_wizard")]
        RecurringSalesInvoiceAutoSendSkippedImportWizard,

        [JsonStringEnumMemberName("ledger_account_report_export_ready")]
        LedgerAccountReportExportReady,

        [JsonStringEnumMemberName("recurring_sales_invoice_failed_deleted_contact")]
        RecurringSalesInvoiceFailedDeletedContact,

        [JsonStringEnumMemberName("recurring_sales_invoice_create_invoice_failed")]
        RecurringSalesInvoiceCreateInvoiceFailed,

        [JsonStringEnumMemberName("sales_invoice_simplerinvoicing_delivery_failed_unroutable")]
        SalesInvoiceSimplerInvoicingDeliveryFailedUnroutable,

        [JsonStringEnumMemberName("purchase_invoice_received_simplerinvoicing")]
        PurchaseInvoiceReceivedSimplerInvoicing,

        [JsonStringEnumMemberName("sales_invoice_simplerinvoicing_delivery_error")]
        SalesInvoiceSimplerInvoicingDeliveryError,

        [JsonStringEnumMemberName("purchase_transaction_expired")]
        PurchaseTransactionExpired,

        [JsonStringEnumMemberName("sales_invoice_si_delivery_failed_contact_unreachable")]
        SalesInvoiceSiDeliveryFailedContactUnreachable,

        [JsonStringEnumMemberName("sales_invoice_si_delivery_failed_deactivated")]
        SalesInvoiceSiDeliveryFailedDeactivated,

        [JsonStringEnumMemberName("sales_invoice_si_delivery_failed_identity_unverified")]
        SalesInvoiceSiDeliveryFailedIdentityUnverified,

        [JsonStringEnumMemberName("sales_invoice_si_delivery_failed_length_exceeded")]
        SalesInvoiceSiDeliveryFailedLengthExceeded,

        [JsonStringEnumMemberName("recurring_document_stopped_by_contact_delete")]
        RecurringDocumentStoppedByContactDelete,

        [JsonStringEnumMemberName("sales_invoice_email_previously_bounced")]
        SalesInvoiceEmailPreviouslyBounced,

        [JsonStringEnumMemberName("estimate_email_previously_bounced")]
        EstimateEmailPreviouslyBounced,

        [JsonStringEnumMemberName("email_domain_invalidated")]
        EmailDomainInvalidated,

        [JsonStringEnumMemberName("external_sales_invoice_invalid_ubl")]
        ExternalSalesInvoiceInvalidUbl,

        [JsonStringEnumMemberName("sales_invoice_email_invalid_address")]
        SalesInvoiceEmailInvalidAddress,

        [JsonStringEnumMemberName("estimate_email_invalid_address")]
        EstimateEmailInvalidAddress,

        [JsonStringEnumMemberName("gateway_connection_terminated")]
        GatewayConnectionTerminated,

        [JsonStringEnumMemberName("sales_invoice_email_payload_too_large")]
        SalesInvoiceEmailPayloadTooLarge,

        [JsonStringEnumMemberName("estimate_email_payload_too_large")]
        EstimateEmailPayloadTooLarge,

        [JsonStringEnumMemberName("ponto_organization_not_activated")]
        PontoOrganizationNotActivated,

        [JsonStringEnumMemberName("ponto_financial_institution_deprecated")]
        PontoFinancialInstitutionDeprecated,

        [JsonStringEnumMemberName("contact_email_delivery_failed")]
        ContactEmailDeliveryFailed,

        [JsonStringEnumMemberName("contact_email_marked_as_spam")]
        ContactEmailMarkedAsSpam,

        [JsonStringEnumMemberName("contact_email_previously_bounced")]
        ContactEmailPreviouslyBounced,

        [JsonStringEnumMemberName("contact_email_invalid_address")]
        ContactEmailInvalidAddress,

        [JsonStringEnumMemberName("contact_email_payload_too_large")]
        ContactEmailPayloadTooLarge,

        [JsonStringEnumMemberName("sales_invoice_scheduling_failed_due_to_payment_information")]
        SalesInvoiceSchedulingFailedDueToPaymentInformation,

        [JsonStringEnumMemberName("sales_invoice_collecting_failed_missing_subscription")]
        SalesInvoiceCollectingFailedMissingSubscription,

        [JsonStringEnumMemberName("sales_invoice_si_delivery_failed_ubl_validation_failed")]
        SalesInvoiceSiDeliveryFailedUblValidationFailed,

        [JsonStringEnumMemberName("sales_invoice_email_sender_limit")]
        SalesInvoiceEmailSenderLimit,

        [JsonStringEnumMemberName("estimate_email_sender_limit")]
        EstimateEmailSenderLimit,

        [JsonStringEnumMemberName("contact_email_sender_limit")]
        ContactEmailSenderLimit,

        [JsonStringEnumMemberName("sales_invoice_email_invalid_attachment")]
        SalesInvoiceEmailInvalidAttachment,

        [JsonStringEnumMemberName("estimate_email_invalid_attachment")]
        EstimateEmailInvalidAttachment,

        [JsonStringEnumMemberName("contact_email_invalid_attachment")]
        ContactEmailInvalidAttachment,

        [JsonStringEnumMemberName("sales_invoice_collecting_failed_monthly_limit_exceeded")]
        SalesInvoiceCollectingFailedMonthlyLimitExceeded,

        [JsonStringEnumMemberName("adyen_verification_error")]
        AdyenVerificationError,

        [JsonStringEnumMemberName("contact_email_not_present")]
        ContactEmailNotPresent,

        [JsonStringEnumMemberName("financial_mutation_failed")]
        FinancialMutationFailed,

        [JsonStringEnumMemberName("sales_invoice_si_delivery_failed_invalid_sender")]
        SalesInvoiceSiDeliveryFailedInvalidSender,

        [JsonStringEnumMemberName("sales_invoice_tax_number_invalid")]
        SalesInvoiceTaxNumberInvalid,

        [JsonStringEnumMemberName("payment_transaction_no_positive_payment")]
        PaymentTransactionNoPositivePayment,

        [JsonStringEnumMemberName("financial_mutation_payment_locked")]
        FinancialMutationPaymentLocked
    }
}