using System.Text.Json.Serialization;

namespace Moneybird.Net.Entities.Webhooks
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum WebhookEvent
    {
        [JsonStringEnumMemberName("administration_activated")]
        AdministrationActivated,

        [JsonStringEnumMemberName("administration_added")]
        AdministrationAdded,

        [JsonStringEnumMemberName("administration_cancelled")]
        AdministrationCancelled,

        [JsonStringEnumMemberName("administration_changed")]
        AdministrationChanged,

        [JsonStringEnumMemberName("administration_deleted")]
        AdministrationDeleted,

        [JsonStringEnumMemberName("administration_reactivated")]
        AdministrationReactivated,

        [JsonStringEnumMemberName("administration_removed")]
        AdministrationRemoved,

        [JsonStringEnumMemberName("administration_suspended")]
        AdministrationSuspended,

        [JsonStringEnumMemberName("administration_automatic_bookers_activated")]
        AdministrationAutomaticBookersActivated,

        [JsonStringEnumMemberName("administration_automatic_bookers_deactivated")]
        AdministrationAutomaticBookersDeactivated,

        [JsonStringEnumMemberName("administration_data_analysis_permission_unset")]
        AdministrationDataAnalysisPermissionUnset,

        [JsonStringEnumMemberName("administration_data_analysis_permission_set")]
        AdministrationDataAnalysisPermissionSet,

        [JsonStringEnumMemberName("administration_details_edited")]
        AdministrationDetailsEdited,

        [JsonStringEnumMemberName("administration_moneybird_banking_requested")]
        AdministrationMoneybirdBankingRequested,

        [JsonStringEnumMemberName("administration_moneybird_banking_tax_information_sent")]
        AdministrationMoneybirdBankingTaxInformationSent,

        [JsonStringEnumMemberName("administration_moneybird_payments_activated")]
        AdministrationMoneybirdPaymentsActivated,

        [JsonStringEnumMemberName("administration_payments_without_proof_activated")]
        AdministrationPaymentsWithoutProofActivated,

        [JsonStringEnumMemberName("administration_payments_without_proof_deactivated")]
        AdministrationPaymentsWithoutProofDeactivated,

        [JsonStringEnumMemberName("administration_update_period_locked_until")]
        AdministrationUpdatePeriodLockedUntil,

        [JsonStringEnumMemberName("administration_legacy_tax_number_updated")]
        AdministrationLegacyTaxNumberUpdated,
        
        [JsonStringEnumMemberName("adviser_updated")]
        AdviserUpdated,

        [JsonStringEnumMemberName("adviser_created")]
        AdviserCreated,

        [JsonStringEnumMemberName("adviser_deleted")]
        AdviserDeleted,

        [JsonStringEnumMemberName("adviser_updated_photo")]
        AdviserUpdatedPhoto,

        [JsonStringEnumMemberName("adviser_email_concept_state_sent")]
        AdviserEmailConceptStateSent,

        [JsonStringEnumMemberName("adviser_email_published_state_sent")]
        AdviserEmailPublishedStateSent,

        [JsonStringEnumMemberName("adviser_experience_created")]
        AdviserExperienceCreated,

        [JsonStringEnumMemberName("adviser_experience_updated")]
        AdviserExperienceUpdated,

        [JsonStringEnumMemberName("adviser_experience_deleted")]
        AdviserExperienceDeleted,

        [JsonStringEnumMemberName("adviser_education_created")]
        AdviserEducationCreated,

        [JsonStringEnumMemberName("adviser_education_updated")]
        AdviserEducationUpdated,

        [JsonStringEnumMemberName("adviser_education_deleted")]
        AdviserEducationDeleted,

        [JsonStringEnumMemberName("adviser_company_created")]
        AdviserCompanyCreated,

        [JsonStringEnumMemberName("adviser_company_updated")]
        AdviserCompanyUpdated,

        [JsonStringEnumMemberName("adviser_company_photo")]
        AdviserCompanyPhoto,

        [JsonStringEnumMemberName("adviser_company_location_created")]
        AdviserCompanyLocationCreated,

        [JsonStringEnumMemberName("adviser_company_location_deleted")]
        AdviserCompanyLocationDeleted,

        [JsonStringEnumMemberName("adviser_company_review_deleted")]
        AdviserCompanyReviewDeleted,

        [JsonStringEnumMemberName("advisers_location_created")]
        AdvisersLocationCreated,

        [JsonStringEnumMemberName("advisers_location_deleted")]
        AdvisersLocationDeleted,

        [JsonStringEnumMemberName("adyen_banking_bank_transfer_permission_created")]
        AdyenBankingBankTransferPermissionCreated,

        [JsonStringEnumMemberName("adyen_banking_bank_transfer_permission_revoked")]
        AdyenBankingBankTransferPermissionRevoked,

        [JsonStringEnumMemberName("adyen_payment_instrument_created")]
        AdyenPaymentInstrumentCreated,

        [JsonStringEnumMemberName("adyen_payment_instrument_updated")]
        AdyenPaymentInstrumentUpdated,

        [JsonStringEnumMemberName("booking_rule_created")]
        BookingRuleCreated,

        [JsonStringEnumMemberName("booking_rule_updated")]
        BookingRuleUpdated,

        [JsonStringEnumMemberName("booking_rule_destroyed")]
        BookingRuleDestroyed,

        [JsonStringEnumMemberName("contact_archived")]
        ContactArchived,

        [JsonStringEnumMemberName("contact_activated")]
        ContactActivated,

        [JsonStringEnumMemberName("contact_changed")]
        ContactChanged,

        [JsonStringEnumMemberName("contact_created")]
        ContactCreated,

        [JsonStringEnumMemberName("contact_created_from_checkout_order")]
        ContactCreatedFromCheckoutOrder,

        [JsonStringEnumMemberName("contact_destroyed")]
        ContactDestroyed,

        [JsonStringEnumMemberName("contact_mandate_request_failed")]
        ContactMandateRequestFailed,

        [JsonStringEnumMemberName("contact_mandate_request_initiated")]
        ContactMandateRequestInitiated,

        [JsonStringEnumMemberName("contact_mandate_request_succeeded")]
        ContactMandateRequestSucceeded,

        [JsonStringEnumMemberName("contact_merged")]
        ContactMerged,

        [JsonStringEnumMemberName("contact_person_created")]
        ContactPersonCreated,

        [JsonStringEnumMemberName("contact_person_destroyed")]
        ContactPersonDestroyed,

        [JsonStringEnumMemberName("contact_person_updated")]
        ContactPersonUpdated,

        [JsonStringEnumMemberName("credit_invoice_created_from_original")]
        CreditInvoiceCreatedFromOriginal,

        [JsonStringEnumMemberName("default_identity_updated")]
        DefaultIdentityUpdated,

        [JsonStringEnumMemberName("default_identity_verification_document_uploaded")]
        DefaultIdentityVerificationDocumentUploaded,

        [JsonStringEnumMemberName("default_tax_rate_created")]
        DefaultTaxRateCreated,

        [JsonStringEnumMemberName("direct_bank_link_activated")]
        DirectBankLinkActivated,

        [JsonStringEnumMemberName("direct_debit_transaction_created")]
        DirectDebitTransactionCreated,

        [JsonStringEnumMemberName("direct_debit_transaction_deleted")]
        DirectDebitTransactionDeleted,

        [JsonStringEnumMemberName("document_attachment_skipped")]
        DocumentAttachmentSkipped,

        [JsonStringEnumMemberName("document_created_from_original")]
        DocumentCreatedFromOriginal,

        [JsonStringEnumMemberName("document_destroyed")]
        DocumentDestroyed,

        [JsonStringEnumMemberName("document_expired")]
        DocumentExpired,

        [JsonStringEnumMemberName("document_recurred")]
        DocumentRecurred,

        [JsonStringEnumMemberName("document_saved")]
        DocumentSaved,

        [JsonStringEnumMemberName("document_saved_from_email")]
        DocumentSavedFromEmail,

        [JsonStringEnumMemberName("document_saved_from_si")]
        DocumentSavedFromSi,

        [JsonStringEnumMemberName("document_style_created")]
        DocumentStyleCreated,

        [JsonStringEnumMemberName("document_style_destroyed")]
        DocumentStyleDestroyed,

        [JsonStringEnumMemberName("document_style_updated")]
        DocumentStyleUpdated,

        [JsonStringEnumMemberName("document_updated")]
        DocumentUpdated,
        
        [JsonStringEnumMemberName("email_domain_deactivated")]
        EmailDomainDeactivated,

        [JsonStringEnumMemberName("email_domain_validated")]
        EmailDomainValidated,

        [JsonStringEnumMemberName("estimate_accepted_contact")]
        EstimateAcceptedContact,

        [JsonStringEnumMemberName("estimate_billed")]
        EstimateBilled,

        [JsonStringEnumMemberName("estimate_created")]
        EstimateCreated,

        [JsonStringEnumMemberName("estimate_created_from_original")]
        EstimateCreatedFromOriginal,

        [JsonStringEnumMemberName("estimate_created_from_original_invoice")]
        EstimateCreatedFromOriginalInvoice,

        [JsonStringEnumMemberName("estimate_destroyed")]
        EstimateDestroyed,

        [JsonStringEnumMemberName("estimate_mark_accepted")]
        EstimateMarkAccepted,

        [JsonStringEnumMemberName("estimate_mark_archived")]
        EstimateMarkArchived,

        [JsonStringEnumMemberName("estimate_mark_billed")]
        EstimateMarkBilled,

        [JsonStringEnumMemberName("estimate_mark_late")]
        EstimateMarkLate,

        [JsonStringEnumMemberName("estimate_mark_open")]
        EstimateMarkOpen,

        [JsonStringEnumMemberName("estimate_mark_rejected")]
        EstimateMarkRejected,

        [JsonStringEnumMemberName("estimate_send_email")]
        EstimateSendEmail,

        [JsonStringEnumMemberName("estimate_send_manually")]
        EstimateSendManually,

        [JsonStringEnumMemberName("estimate_send_post")]
        EstimateSendPost,

        [JsonStringEnumMemberName("estimate_send_post_cancelled")]
        EstimateSendPostCancelled,

        [JsonStringEnumMemberName("estimate_send_post_confirmation")]
        EstimateSendPostConfirmation,

        [JsonStringEnumMemberName("estimate_signed_sender")]
        EstimateSignedSender,

        [JsonStringEnumMemberName("estimate_state_changed_to_late")]
        EstimateStateChangedToLate,

        [JsonStringEnumMemberName("estimate_updated")]
        EstimateUpdated,

        [JsonStringEnumMemberName("expert_contact_request")]
        ExpertContactRequest,

        [JsonStringEnumMemberName("expert_status_accepted")]
        ExpertStatusAccepted,

        [JsonStringEnumMemberName("expert_status_invited")]
        ExpertStatusInvited,

        [JsonStringEnumMemberName("expert_status_revoked")]
        ExpertStatusRevoked,

        [JsonStringEnumMemberName("expert_status_withdrawn")]
        ExpertStatusWithdrawn,

        [JsonStringEnumMemberName("expert_warning_month0")]
        ExpertWarningMonth0,

        [JsonStringEnumMemberName("expert_warning_month6")]
        ExpertWarningMonth6,

        [JsonStringEnumMemberName("expert_warning_month11")]
        ExpertWarningMonth11,

        [JsonStringEnumMemberName("external_sales_invoice_created")]
        ExternalSalesInvoiceCreated,

        [JsonStringEnumMemberName("external_sales_invoice_destroyed")]
        ExternalSalesInvoiceDestroyed,

        [JsonStringEnumMemberName("external_sales_invoice_marked_as_dubious")]
        ExternalSalesInvoiceMarkedAsDubious,

        [JsonStringEnumMemberName("external_sales_invoice_marked_as_uncollectible")]
        ExternalSalesInvoiceMarkedAsUncollectible,

        [JsonStringEnumMemberName("external_sales_invoice_updated")]
        ExternalSalesInvoiceUpdated,

        [JsonStringEnumMemberName("external_sales_invoice_state_changed_to_late")]
        ExternalSalesInvoiceStateChangedToLate,

        [JsonStringEnumMemberName("external_sales_invoice_state_changed_to_open")]
        ExternalSalesInvoiceStateChangedToOpen,

        [JsonStringEnumMemberName("external_sales_invoice_state_changed_to_paid")]
        ExternalSalesInvoiceStateChangedToPaid,

        [JsonStringEnumMemberName("external_sales_invoice_state_changed_to_uncollectible")]
        ExternalSalesInvoiceStateChangedToUncollectible,

        [JsonStringEnumMemberName("feature_preference_opt_in")]
        FeaturePreferenceOptIn,

        [JsonStringEnumMemberName("feature_preference_opt_out")]
        FeaturePreferenceOptOut,

        [JsonStringEnumMemberName("feed_entry_snoozed")]
        FeedEntrySnoozed,

        [JsonStringEnumMemberName("feed_entry_unsnoozed")]
        FeedEntryUnsnoozed,

        [JsonStringEnumMemberName("financial_account_activated")]
        FinancialAccountActivated,

        [JsonStringEnumMemberName("financial_account_created")]
        FinancialAccountCreated,

        [JsonStringEnumMemberName("financial_account_deactivated")]
        FinancialAccountDeactivated,

        [JsonStringEnumMemberName("financial_account_destroyed")]
        FinancialAccountDestroyed,

        [JsonStringEnumMemberName("financial_account_bank_link_created")]
        FinancialAccountBankLinkCreated,

        [JsonStringEnumMemberName("financial_account_bank_link_destroyed")]
        FinancialAccountBankLinkDestroyed,

        [JsonStringEnumMemberName("financial_account_bank_link_updated")]
        FinancialAccountBankLinkUpdated,

        [JsonStringEnumMemberName("financial_account_renamed")]
        FinancialAccountRenamed,

        [JsonStringEnumMemberName("financial_statement_created")]
        FinancialStatementCreated,

        [JsonStringEnumMemberName("financial_statement_destroyed")]
        FinancialStatementDestroyed,

        [JsonStringEnumMemberName("financial_statement_updated")]
        FinancialStatementUpdated,
        
        [JsonStringEnumMemberName("goal_completed")]
        GoalCompleted,

        [JsonStringEnumMemberName("goal_uncompleted")]
        GoalUncompleted,

        [JsonStringEnumMemberName("identity_created")]
        IdentityCreated,

        [JsonStringEnumMemberName("identity_destroyed")]
        IdentityDestroyed,

        [JsonStringEnumMemberName("identity_updated")]
        IdentityUpdated,

        [JsonStringEnumMemberName("ledger_account_activated")]
        LedgerAccountActivated,

        [JsonStringEnumMemberName("ledger_account_booking_created")]
        LedgerAccountBookingCreated,

        [JsonStringEnumMemberName("ledger_account_booking_destroyed")]
        LedgerAccountBookingDestroyed,

        [JsonStringEnumMemberName("ledger_account_created")]
        LedgerAccountCreated,

        [JsonStringEnumMemberName("ledger_account_deactivated")]
        LedgerAccountDeactivated,

        [JsonStringEnumMemberName("ledger_account_destroyed")]
        LedgerAccountDestroyed,

        [JsonStringEnumMemberName("ledger_account_updated")]
        LedgerAccountUpdated,

        [JsonStringEnumMemberName("legal_terms_acceptation_created")]
        LegalTermsAcceptationCreated,

        [JsonStringEnumMemberName("legal_terms_acceptation_email_delivery_failed")]
        LegalTermsAcceptationEmailDeliveryFailed,

        [JsonStringEnumMemberName("legal_terms_acceptation_email_invalid_address")]
        LegalTermsAcceptationEmailInvalidAddress,

        [JsonStringEnumMemberName("legal_terms_acceptation_email_invalid_attachment")]
        LegalTermsAcceptationEmailInvalidAttachment,

        [JsonStringEnumMemberName("legal_terms_acceptation_email_marked_as_spam")]
        LegalTermsAcceptationEmailMarkedAsSpam,

        [JsonStringEnumMemberName("legal_terms_acceptation_email_payload_too_large")]
        LegalTermsAcceptationEmailPayloadTooLarge,

        [JsonStringEnumMemberName("legal_terms_acceptation_email_previously_bounced")]
        LegalTermsAcceptationEmailPreviouslyBounced,

        [JsonStringEnumMemberName("legal_terms_acceptation_email_sent")]
        LegalTermsAcceptationEmailSent,

        [JsonStringEnumMemberName("mollie_credential_created")]
        MollieCredentialCreated,

        [JsonStringEnumMemberName("mollie_credential_destroyed")]
        MollieCredentialDestroyed,

        [JsonStringEnumMemberName("moneybird_banking_transfer_initiated")]
        MoneybirdBankingTransferInitiated,

        [JsonStringEnumMemberName("moneybird_banking_transfer_failed")]
        MoneybirdBankingTransferFailed,

        [JsonStringEnumMemberName("multi_factor_required")]
        MultiFactorRequired,

        [JsonStringEnumMemberName("note_created")]
        NoteCreated,

        [JsonStringEnumMemberName("note_destroyed")]
        NoteDestroyed,

        [JsonStringEnumMemberName("order_created")]
        OrderCreated,

        [JsonStringEnumMemberName("payment_destroyed")]
        PaymentDestroyed,

        [JsonStringEnumMemberName("payment_linked_to_financial_mutation")]
        PaymentLinkedToFinancialMutation,

        [JsonStringEnumMemberName("payment_registered")]
        PaymentRegistered,

        [JsonStringEnumMemberName("payment_send_email")]
        PaymentSendEmail,

        [JsonStringEnumMemberName("payment_method_edited")]
        PaymentMethodEdited,

        [JsonStringEnumMemberName("payment_transaction_authorized")]
        PaymentTransactionAuthorized,

        [JsonStringEnumMemberName("payment_transaction_awaiting_authorization")]
        PaymentTransactionAwaitingAuthorization,

        [JsonStringEnumMemberName("payment_transaction_batch_cancelled")]
        PaymentTransactionBatchCancelled,

        [JsonStringEnumMemberName("payment_transaction_batch_created")]
        PaymentTransactionBatchCreated,

        [JsonStringEnumMemberName("payment_transaction_executing")]
        PaymentTransactionExecuting,

        [JsonStringEnumMemberName("payment_transaction_paid")]
        PaymentTransactionPaid,

        [JsonStringEnumMemberName("payment_transaction_pending")]
        PaymentTransactionPending,

        [JsonStringEnumMemberName("payment_transaction_rejected")]
        PaymentTransactionRejected,

        [JsonStringEnumMemberName("payment_transaction_technically_validated")]
        PaymentTransactionTechnicallyValidated,

        [JsonStringEnumMemberName("ponto_connected")]
        PontoConnected,

        [JsonStringEnumMemberName("ponto_disconnected")]
        PontoDisconnected,

        [JsonStringEnumMemberName("ponto_direct_bank_link_activated")]
        PontoDirectBankLinkActivated,

        [JsonStringEnumMemberName("ponto_direct_bank_link_expired")]
        PontoDirectBankLinkExpired,

        [JsonStringEnumMemberName("product_activated")]
        ProductActivated,

        [JsonStringEnumMemberName("product_created")]
        ProductCreated,

        [JsonStringEnumMemberName("product_deactivated")]
        ProductDeactivated,

        [JsonStringEnumMemberName("product_destroyed")]
        ProductDestroyed,

        [JsonStringEnumMemberName("product_updated")]
        ProductUpdated,

        [JsonStringEnumMemberName("project_activated")]
        ProjectActivated,

        [JsonStringEnumMemberName("project_created")]
        ProjectCreated,

        [JsonStringEnumMemberName("project_archived")]
        ProjectArchived,

        [JsonStringEnumMemberName("project_destroyed")]
        ProjectDestroyed,

        [JsonStringEnumMemberName("project_updated")]
        ProjectUpdated,

        [JsonStringEnumMemberName("purchase_transaction_added_to_batch")]
        PurchaseTransactionAddedToBatch,

        [JsonStringEnumMemberName("purchase_transaction_authorized")]
        PurchaseTransactionAuthorized,

        [JsonStringEnumMemberName("purchase_transaction_awaiting_authorization")]
        PurchaseTransactionAwaitingAuthorization,

        [JsonStringEnumMemberName("purchase_transaction_batch_cancelled")]
        PurchaseTransactionBatchCancelled,

        [JsonStringEnumMemberName("purchase_transaction_batch_created")]
        PurchaseTransactionBatchCreated,

        [JsonStringEnumMemberName("purchase_transaction_created")]
        PurchaseTransactionCreated,

        [JsonStringEnumMemberName("purchase_transaction_deleted")]
        PurchaseTransactionDeleted,

        [JsonStringEnumMemberName("purchase_transaction_executing")]
        PurchaseTransactionExecuting,

        [JsonStringEnumMemberName("purchase_transaction_paid")]
        PurchaseTransactionPaid,

        [JsonStringEnumMemberName("purchase_transaction_pending")]
        PurchaseTransactionPending,

        [JsonStringEnumMemberName("purchase_transaction_rejected")]
        PurchaseTransactionRejected,

        [JsonStringEnumMemberName("purchase_transaction_technically_validated")]
        PurchaseTransactionTechnicallyValidated,

        [JsonStringEnumMemberName("recurring_sales_invoice_auto_send_forcefully_disabled")]
        RecurringSalesInvoiceAutoSendForcefullyDisabled,

        [JsonStringEnumMemberName("recurring_sales_invoice_created")]
        RecurringSalesInvoiceCreated,

        [JsonStringEnumMemberName("recurring_sales_invoice_created_from_original")]
        RecurringSalesInvoiceCreatedFromOriginal,

        [JsonStringEnumMemberName("recurring_sales_invoice_created_from_original_recurring")]
        RecurringSalesInvoiceCreatedFromOriginalRecurring,

        [JsonStringEnumMemberName("recurring_sales_invoice_creating_skipped_due_to_limits")]
        RecurringSalesInvoiceCreatingSkippedDueToLimits,

        [JsonStringEnumMemberName("recurring_sales_invoice_deactivated")]
        RecurringSalesInvoiceDeactivated,

        [JsonStringEnumMemberName("recurring_sales_invoice_destroyed")]
        RecurringSalesInvoiceDestroyed,

        [JsonStringEnumMemberName("recurring_sales_invoice_invoice_created")]
        RecurringSalesInvoiceInvoiceCreated,

        [JsonStringEnumMemberName("recurring_sales_invoice_started_auto_send")]
        RecurringSalesInvoiceStartedAutoSend,

        [JsonStringEnumMemberName("recurring_sales_invoice_stopped_auto_send")]
        RecurringSalesInvoiceStoppedAutoSend,

        [JsonStringEnumMemberName("recurring_sales_invoice_updated")]
        RecurringSalesInvoiceUpdated,

        [JsonStringEnumMemberName("rule_activated")]
        RuleActivated,

        [JsonStringEnumMemberName("rule_updated")]
        RuleUpdated,

        [JsonStringEnumMemberName("rule_deactivated")]
        RuleDeactivated,

        [JsonStringEnumMemberName("rule_destroyed")]
        RuleDestroyed,
        
        [JsonStringEnumMemberName("sales_invoice_created")]
        SalesInvoiceCreated,

        [JsonStringEnumMemberName("sales_invoice_created_based_on_estimate")]
        SalesInvoiceCreatedBasedOnEstimate,

        [JsonStringEnumMemberName("sales_invoice_created_based_on_recurring")]
        SalesInvoiceCreatedBasedOnRecurring,

        [JsonStringEnumMemberName("sales_invoice_created_based_on_subscription")]
        SalesInvoiceCreatedBasedOnSubscription,

        [JsonStringEnumMemberName("sales_invoice_created_from_checkout_order")]
        SalesInvoiceCreatedFromCheckoutOrder,

        [JsonStringEnumMemberName("sales_invoice_created_from_original")]
        SalesInvoiceCreatedFromOriginal,

        [JsonStringEnumMemberName("sales_invoice_destroyed")]
        SalesInvoiceDestroyed,

        [JsonStringEnumMemberName("sales_invoice_marked_as_dubious")]
        SalesInvoiceMarkedAsDubious,

        [JsonStringEnumMemberName("sales_invoice_marked_as_uncollectible")]
        SalesInvoiceMarkedAsUncollectible,

        [JsonStringEnumMemberName("sales_invoice_merged")]
        SalesInvoiceMerged,

        [JsonStringEnumMemberName("sales_invoice_merged_with_recurring_sales_invoice")]
        SalesInvoiceMergedWithRecurringSalesInvoice,

        [JsonStringEnumMemberName("sales_invoice_paused")]
        SalesInvoicePaused,

        [JsonStringEnumMemberName("sales_invoice_revert_dubious")]
        SalesInvoiceRevertDubious,

        [JsonStringEnumMemberName("sales_invoice_revert_uncollectible")]
        SalesInvoiceRevertUncollectible,

        [JsonStringEnumMemberName("sales_invoice_send_email")]
        SalesInvoiceSendEmail,

        [JsonStringEnumMemberName("sales_invoice_send_manually")]
        SalesInvoiceSendManually,

        [JsonStringEnumMemberName("sales_invoice_send_post")]
        SalesInvoiceSendPost,

        [JsonStringEnumMemberName("sales_invoice_send_post_confirmation")]
        SalesInvoiceSendPostConfirmation,

        [JsonStringEnumMemberName("sales_invoice_send_post_cancelled")]
        SalesInvoiceSendPostCancelled,

        [JsonStringEnumMemberName("sales_invoice_send_reminder_email")]
        SalesInvoiceSendReminderEmail,

        [JsonStringEnumMemberName("sales_invoice_send_reminder_manually")]
        SalesInvoiceSendReminderManually,

        [JsonStringEnumMemberName("sales_invoice_send_reminder_post")]
        SalesInvoiceSendReminderPost,

        [JsonStringEnumMemberName("sales_invoice_send_reminder_post_confirmation")]
        SalesInvoiceSendReminderPostConfirmation,

        [JsonStringEnumMemberName("sales_invoice_send_si")]
        SalesInvoiceSendSi,

        [JsonStringEnumMemberName("sales_invoice_send_si_delivered")]
        SalesInvoiceSendSiDelivered,

        [JsonStringEnumMemberName("sales_invoice_send_si_error")]
        SalesInvoiceSendSiError,

        [JsonStringEnumMemberName("sales_invoice_send_to_payt")]
        SalesInvoiceSendToPayt,

        [JsonStringEnumMemberName("sales_invoice_state_changed_to_draft")]
        SalesInvoiceStateChangedToDraft,

        [JsonStringEnumMemberName("sales_invoice_state_changed_to_late")]
        SalesInvoiceStateChangedToLate,

        [JsonStringEnumMemberName("sales_invoice_state_changed_to_open")]
        SalesInvoiceStateChangedToOpen,

        [JsonStringEnumMemberName("sales_invoice_state_changed_to_paid")]
        SalesInvoiceStateChangedToPaid,

        [JsonStringEnumMemberName("sales_invoice_state_changed_to_pending_payment")]
        SalesInvoiceStateChangedToPendingPayment,

        [JsonStringEnumMemberName("sales_invoice_state_changed_to_reminded")]
        SalesInvoiceStateChangedToReminded,

        [JsonStringEnumMemberName("sales_invoice_state_changed_to_scheduled")]
        SalesInvoiceStateChangedToScheduled,

        [JsonStringEnumMemberName("sales_invoice_state_changed_to_uncollectible")]
        SalesInvoiceStateChangedToUncollectible,

        [JsonStringEnumMemberName("sales_invoice_unpaused")]
        SalesInvoiceUnpaused,

        [JsonStringEnumMemberName("sales_invoice_updated")]
        SalesInvoiceUpdated,

        [JsonStringEnumMemberName("send_payment_email")]
        SendPaymentEmail,

        [JsonStringEnumMemberName("send_payment_unsuccessful_email")]
        SendPaymentUnsuccessfulEmail,

        [JsonStringEnumMemberName("sepa_direct_debit_limit_updated")]
        SepaDirectDebitLimitUpdated,

        [JsonStringEnumMemberName("subgoal_assigned")]
        SubgoalAssigned,

        [JsonStringEnumMemberName("subgoal_completed")]
        SubgoalCompleted,

        [JsonStringEnumMemberName("subgoal_uncompleted")]
        SubgoalUncompleted,

        [JsonStringEnumMemberName("subscription_cancelled")]
        SubscriptionCancelled,

        [JsonStringEnumMemberName("subscription_created")]
        SubscriptionCreated,

        [JsonStringEnumMemberName("subscription_destroyed")]
        SubscriptionDestroyed,

        [JsonStringEnumMemberName("subscription_edited")]
        SubscriptionEdited,

        [JsonStringEnumMemberName("subscription_updated")]
        SubscriptionUpdated,

        [JsonStringEnumMemberName("tax_rate_activated")]
        TaxRateActivated,

        [JsonStringEnumMemberName("tax_rate_created")]
        TaxRateCreated,

        [JsonStringEnumMemberName("tax_rate_deactivated")]
        TaxRateDeactivated,

        [JsonStringEnumMemberName("tax_rate_destroyed")]
        TaxRateDestroyed,

        [JsonStringEnumMemberName("tax_rate_updated")]
        TaxRateUpdated,

        [JsonStringEnumMemberName("time_entry_created")]
        TimeEntryCreated,

        [JsonStringEnumMemberName("time_entry_destroyed")]
        TimeEntryDestroyed,

        [JsonStringEnumMemberName("time_entry_sales_invoice_created")]
        TimeEntrySalesInvoiceCreated,

        [JsonStringEnumMemberName("time_entry_updated")]
        TimeEntryUpdated,

        [JsonStringEnumMemberName("todo_completed")]
        TodoCompleted,

        [JsonStringEnumMemberName("todo_created")]
        TodoCreated,

        [JsonStringEnumMemberName("todo_destroyed")]
        TodoDestroyed,

        [JsonStringEnumMemberName("todo_opened")]
        TodoOpened,

        [JsonStringEnumMemberName("ultimate_beneficial_owner_verification_document_uploaded")]
        UltimateBeneficialOwnerVerificationDocumentUploaded,

        [JsonStringEnumMemberName("ultimate_benificial_owner_created")]
        UltimateBenificialOwnerCreated,

        [JsonStringEnumMemberName("ultimate_benificial_owner_updated")]
        UltimateBenificialOwnerUpdated,

        [JsonStringEnumMemberName("user_invited")]
        UserInvited,

        [JsonStringEnumMemberName("user_invited_for_call")]
        UserInvitedForCall,

        [JsonStringEnumMemberName("user_removed")]
        UserRemoved,

        [JsonStringEnumMemberName("vat_return_created")]
        VatReturnCreated,

        [JsonStringEnumMemberName("vat_return_received")]
        VatReturnReceived,

        [JsonStringEnumMemberName("vat_return_paid")]
        VatReturnPaid,

        [JsonStringEnumMemberName("vat_suppletion_created")]
        VatSuppletionCreated,

        [JsonStringEnumMemberName("vat_suppletion_received")]
        VatSuppletionReceived,

        [JsonStringEnumMemberName("vat_suppletion_paid")]
        VatSuppletionPaid,

        [JsonStringEnumMemberName("workflow_created")]
        WorkflowCreated,

        [JsonStringEnumMemberName("workflow_deactivated")]
        WorkflowDeactivated,

        [JsonStringEnumMemberName("workflow_destroyed")]
        WorkflowDestroyed,

        [JsonStringEnumMemberName("workflow_updated")]
        WorkflowUpdated
    }
}
