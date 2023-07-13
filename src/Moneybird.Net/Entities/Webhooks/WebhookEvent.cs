using System.Text.Json.Serialization;

namespace Moneybird.Net.Entities.Webhooks
{
    [JsonConverter(typeof(JsonStringEnumMemberConverter))]
    public enum WebhookEvent
    {
        [JsonPropertyName("administration_activated")]
        AdministrationActivated,

        [JsonPropertyName("administration_added")]
        AdministrationAdded,

        [JsonPropertyName("administration_cancelled")]
        AdministrationCancelled,

        [JsonPropertyName("administration_changed")]
        AdministrationChanged,

        [JsonPropertyName("administration_deleted")]
        AdministrationDeleted,

        [JsonPropertyName("administration_reactivated")]
        AdministrationReactivated,

        [JsonPropertyName("administration_removed")]
        AdministrationRemoved,

        [JsonPropertyName("administration_suspended")]
        AdministrationSuspended,

        [JsonPropertyName("administration_automatic_bookers_activated")]
        AdministrationAutomaticBookersActivated,

        [JsonPropertyName("administration_automatic_bookers_deactivated")]
        AdministrationAutomaticBookersDeactivated,

        [JsonPropertyName("administration_data_analysis_permission_unset")]
        AdministrationDataAnalysisPermissionUnset,

        [JsonPropertyName("administration_data_analysis_permission_set")]
        AdministrationDataAnalysisPermissionSet,

        [JsonPropertyName("administration_details_edited")]
        AdministrationDetailsEdited,

        [JsonPropertyName("administration_moneybird_banking_requested")]
        AdministrationMoneybirdBankingRequested,

        [JsonPropertyName("administration_moneybird_banking_tax_information_sent")]
        AdministrationMoneybirdBankingTaxInformationSent,

        [JsonPropertyName("administration_moneybird_payments_activated")]
        AdministrationMoneybirdPaymentsActivated,

        [JsonPropertyName("administration_payments_without_proof_activated")]
        AdministrationPaymentsWithoutProofActivated,

        [JsonPropertyName("administration_payments_without_proof_deactivated")]
        AdministrationPaymentsWithoutProofDeactivated,

        [JsonPropertyName("administration_update_period_locked_until")]
        AdministrationUpdatePeriodLockedUntil,

        [JsonPropertyName("administration_legacy_tax_number_updated")]
        AdministrationLegacyTaxNumberUpdated,
        
        [JsonPropertyName("adviser_updated")]
        AdviserUpdated,

        [JsonPropertyName("adviser_created")]
        AdviserCreated,

        [JsonPropertyName("adviser_deleted")]
        AdviserDeleted,

        [JsonPropertyName("adviser_updated_photo")]
        AdviserUpdatedPhoto,

        [JsonPropertyName("adviser_email_concept_state_sent")]
        AdviserEmailConceptStateSent,

        [JsonPropertyName("adviser_email_published_state_sent")]
        AdviserEmailPublishedStateSent,

        [JsonPropertyName("adviser_experience_created")]
        AdviserExperienceCreated,

        [JsonPropertyName("adviser_experience_updated")]
        AdviserExperienceUpdated,

        [JsonPropertyName("adviser_experience_deleted")]
        AdviserExperienceDeleted,

        [JsonPropertyName("adviser_education_created")]
        AdviserEducationCreated,

        [JsonPropertyName("adviser_education_updated")]
        AdviserEducationUpdated,

        [JsonPropertyName("adviser_education_deleted")]
        AdviserEducationDeleted,

        [JsonPropertyName("adviser_company_created")]
        AdviserCompanyCreated,

        [JsonPropertyName("adviser_company_updated")]
        AdviserCompanyUpdated,

        [JsonPropertyName("adviser_company_photo")]
        AdviserCompanyPhoto,

        [JsonPropertyName("adviser_company_location_created")]
        AdviserCompanyLocationCreated,

        [JsonPropertyName("adviser_company_location_deleted")]
        AdviserCompanyLocationDeleted,

        [JsonPropertyName("adviser_company_review_deleted")]
        AdviserCompanyReviewDeleted,

        [JsonPropertyName("advisers_location_created")]
        AdvisersLocationCreated,

        [JsonPropertyName("advisers_location_deleted")]
        AdvisersLocationDeleted,

        [JsonPropertyName("adyen_banking_bank_transfer_permission_created")]
        AdyenBankingBankTransferPermissionCreated,

        [JsonPropertyName("adyen_banking_bank_transfer_permission_revoked")]
        AdyenBankingBankTransferPermissionRevoked,

        [JsonPropertyName("adyen_payment_instrument_created")]
        AdyenPaymentInstrumentCreated,

        [JsonPropertyName("adyen_payment_instrument_updated")]
        AdyenPaymentInstrumentUpdated,

        [JsonPropertyName("booking_rule_created")]
        BookingRuleCreated,

        [JsonPropertyName("booking_rule_updated")]
        BookingRuleUpdated,

        [JsonPropertyName("booking_rule_destroyed")]
        BookingRuleDestroyed,

        [JsonPropertyName("contact_archived")]
        ContactArchived,

        [JsonPropertyName("contact_activated")]
        ContactActivated,

        [JsonPropertyName("contact_changed")]
        ContactChanged,

        [JsonPropertyName("contact_created")]
        ContactCreated,

        [JsonPropertyName("contact_created_from_checkout_order")]
        ContactCreatedFromCheckoutOrder,

        [JsonPropertyName("contact_destroyed")]
        ContactDestroyed,

        [JsonPropertyName("contact_mandate_request_failed")]
        ContactMandateRequestFailed,

        [JsonPropertyName("contact_mandate_request_initiated")]
        ContactMandateRequestInitiated,

        [JsonPropertyName("contact_mandate_request_succeeded")]
        ContactMandateRequestSucceeded,

        [JsonPropertyName("contact_merged")]
        ContactMerged,

        [JsonPropertyName("contact_person_created")]
        ContactPersonCreated,

        [JsonPropertyName("contact_person_destroyed")]
        ContactPersonDestroyed,

        [JsonPropertyName("contact_person_updated")]
        ContactPersonUpdated,

        [JsonPropertyName("credit_invoice_created_from_original")]
        CreditInvoiceCreatedFromOriginal,

        [JsonPropertyName("default_identity_updated")]
        DefaultIdentityUpdated,

        [JsonPropertyName("default_identity_verification_document_uploaded")]
        DefaultIdentityVerificationDocumentUploaded,

        [JsonPropertyName("default_tax_rate_created")]
        DefaultTaxRateCreated,

        [JsonPropertyName("direct_bank_link_activated")]
        DirectBankLinkActivated,

        [JsonPropertyName("direct_debit_transaction_created")]
        DirectDebitTransactionCreated,

        [JsonPropertyName("direct_debit_transaction_deleted")]
        DirectDebitTransactionDeleted,

        [JsonPropertyName("document_attachment_skipped")]
        DocumentAttachmentSkipped,

        [JsonPropertyName("document_created_from_original")]
        DocumentCreatedFromOriginal,

        [JsonPropertyName("document_destroyed")]
        DocumentDestroyed,

        [JsonPropertyName("document_expired")]
        DocumentExpired,

        [JsonPropertyName("document_recurred")]
        DocumentRecurred,

        [JsonPropertyName("document_saved")]
        DocumentSaved,

        [JsonPropertyName("document_saved_from_email")]
        DocumentSavedFromEmail,

        [JsonPropertyName("document_saved_from_si")]
        DocumentSavedFromSi,

        [JsonPropertyName("document_style_created")]
        DocumentStyleCreated,

        [JsonPropertyName("document_style_destroyed")]
        DocumentStyleDestroyed,

        [JsonPropertyName("document_style_updated")]
        DocumentStyleUpdated,

        [JsonPropertyName("document_updated")]
        DocumentUpdated,
        
        [JsonPropertyName("email_domain_deactivated")]
        EmailDomainDeactivated,

        [JsonPropertyName("email_domain_validated")]
        EmailDomainValidated,

        [JsonPropertyName("estimate_accepted_contact")]
        EstimateAcceptedContact,

        [JsonPropertyName("estimate_billed")]
        EstimateBilled,

        [JsonPropertyName("estimate_created")]
        EstimateCreated,

        [JsonPropertyName("estimate_created_from_original")]
        EstimateCreatedFromOriginal,

        [JsonPropertyName("estimate_created_from_original_invoice")]
        EstimateCreatedFromOriginalInvoice,

        [JsonPropertyName("estimate_destroyed")]
        EstimateDestroyed,

        [JsonPropertyName("estimate_mark_accepted")]
        EstimateMarkAccepted,

        [JsonPropertyName("estimate_mark_archived")]
        EstimateMarkArchived,

        [JsonPropertyName("estimate_mark_billed")]
        EstimateMarkBilled,

        [JsonPropertyName("estimate_mark_late")]
        EstimateMarkLate,

        [JsonPropertyName("estimate_mark_open")]
        EstimateMarkOpen,

        [JsonPropertyName("estimate_mark_rejected")]
        EstimateMarkRejected,

        [JsonPropertyName("estimate_send_email")]
        EstimateSendEmail,

        [JsonPropertyName("estimate_send_manually")]
        EstimateSendManually,

        [JsonPropertyName("estimate_send_post")]
        EstimateSendPost,

        [JsonPropertyName("estimate_send_post_cancelled")]
        EstimateSendPostCancelled,

        [JsonPropertyName("estimate_send_post_confirmation")]
        EstimateSendPostConfirmation,

        [JsonPropertyName("estimate_signed_sender")]
        EstimateSignedSender,

        [JsonPropertyName("estimate_state_changed_to_late")]
        EstimateStateChangedToLate,

        [JsonPropertyName("estimate_updated")]
        EstimateUpdated,

        [JsonPropertyName("expert_contact_request")]
        ExpertContactRequest,

        [JsonPropertyName("expert_status_accepted")]
        ExpertStatusAccepted,

        [JsonPropertyName("expert_status_invited")]
        ExpertStatusInvited,

        [JsonPropertyName("expert_status_revoked")]
        ExpertStatusRevoked,

        [JsonPropertyName("expert_status_withdrawn")]
        ExpertStatusWithdrawn,

        [JsonPropertyName("expert_warning_month0")]
        ExpertWarningMonth0,

        [JsonPropertyName("expert_warning_month6")]
        ExpertWarningMonth6,

        [JsonPropertyName("expert_warning_month11")]
        ExpertWarningMonth11,

        [JsonPropertyName("external_sales_invoice_created")]
        ExternalSalesInvoiceCreated,

        [JsonPropertyName("external_sales_invoice_destroyed")]
        ExternalSalesInvoiceDestroyed,

        [JsonPropertyName("external_sales_invoice_marked_as_dubious")]
        ExternalSalesInvoiceMarkedAsDubious,

        [JsonPropertyName("external_sales_invoice_marked_as_uncollectible")]
        ExternalSalesInvoiceMarkedAsUncollectible,

        [JsonPropertyName("external_sales_invoice_updated")]
        ExternalSalesInvoiceUpdated,

        [JsonPropertyName("external_sales_invoice_state_changed_to_late")]
        ExternalSalesInvoiceStateChangedToLate,

        [JsonPropertyName("external_sales_invoice_state_changed_to_open")]
        ExternalSalesInvoiceStateChangedToOpen,

        [JsonPropertyName("external_sales_invoice_state_changed_to_paid")]
        ExternalSalesInvoiceStateChangedToPaid,

        [JsonPropertyName("external_sales_invoice_state_changed_to_uncollectible")]
        ExternalSalesInvoiceStateChangedToUncollectible,

        [JsonPropertyName("feature_preference_opt_in")]
        FeaturePreferenceOptIn,

        [JsonPropertyName("feature_preference_opt_out")]
        FeaturePreferenceOptOut,

        [JsonPropertyName("feed_entry_snoozed")]
        FeedEntrySnoozed,

        [JsonPropertyName("feed_entry_unsnoozed")]
        FeedEntryUnsnoozed,

        [JsonPropertyName("financial_account_activated")]
        FinancialAccountActivated,

        [JsonPropertyName("financial_account_created")]
        FinancialAccountCreated,

        [JsonPropertyName("financial_account_deactivated")]
        FinancialAccountDeactivated,

        [JsonPropertyName("financial_account_destroyed")]
        FinancialAccountDestroyed,

        [JsonPropertyName("financial_account_bank_link_created")]
        FinancialAccountBankLinkCreated,

        [JsonPropertyName("financial_account_bank_link_destroyed")]
        FinancialAccountBankLinkDestroyed,

        [JsonPropertyName("financial_account_bank_link_updated")]
        FinancialAccountBankLinkUpdated,

        [JsonPropertyName("financial_account_renamed")]
        FinancialAccountRenamed,

        [JsonPropertyName("financial_statement_created")]
        FinancialStatementCreated,

        [JsonPropertyName("financial_statement_destroyed")]
        FinancialStatementDestroyed,

        [JsonPropertyName("financial_statement_updated")]
        FinancialStatementUpdated,
        
        [JsonPropertyName("goal_completed")]
        GoalCompleted,

        [JsonPropertyName("goal_uncompleted")]
        GoalUncompleted,

        [JsonPropertyName("identity_created")]
        IdentityCreated,

        [JsonPropertyName("identity_destroyed")]
        IdentityDestroyed,

        [JsonPropertyName("identity_updated")]
        IdentityUpdated,

        [JsonPropertyName("ledger_account_activated")]
        LedgerAccountActivated,

        [JsonPropertyName("ledger_account_booking_created")]
        LedgerAccountBookingCreated,

        [JsonPropertyName("ledger_account_booking_destroyed")]
        LedgerAccountBookingDestroyed,

        [JsonPropertyName("ledger_account_created")]
        LedgerAccountCreated,

        [JsonPropertyName("ledger_account_deactivated")]
        LedgerAccountDeactivated,

        [JsonPropertyName("ledger_account_destroyed")]
        LedgerAccountDestroyed,

        [JsonPropertyName("ledger_account_updated")]
        LedgerAccountUpdated,

        [JsonPropertyName("legal_terms_acceptation_created")]
        LegalTermsAcceptationCreated,

        [JsonPropertyName("legal_terms_acceptation_email_delivery_failed")]
        LegalTermsAcceptationEmailDeliveryFailed,

        [JsonPropertyName("legal_terms_acceptation_email_invalid_address")]
        LegalTermsAcceptationEmailInvalidAddress,

        [JsonPropertyName("legal_terms_acceptation_email_invalid_attachment")]
        LegalTermsAcceptationEmailInvalidAttachment,

        [JsonPropertyName("legal_terms_acceptation_email_marked_as_spam")]
        LegalTermsAcceptationEmailMarkedAsSpam,

        [JsonPropertyName("legal_terms_acceptation_email_payload_too_large")]
        LegalTermsAcceptationEmailPayloadTooLarge,

        [JsonPropertyName("legal_terms_acceptation_email_previously_bounced")]
        LegalTermsAcceptationEmailPreviouslyBounced,

        [JsonPropertyName("legal_terms_acceptation_email_sent")]
        LegalTermsAcceptationEmailSent,

        [JsonPropertyName("mollie_credential_created")]
        MollieCredentialCreated,

        [JsonPropertyName("mollie_credential_destroyed")]
        MollieCredentialDestroyed,

        [JsonPropertyName("moneybird_banking_transfer_initiated")]
        MoneybirdBankingTransferInitiated,

        [JsonPropertyName("moneybird_banking_transfer_failed")]
        MoneybirdBankingTransferFailed,

        [JsonPropertyName("multi_factor_required")]
        MultiFactorRequired,

        [JsonPropertyName("note_created")]
        NoteCreated,

        [JsonPropertyName("note_destroyed")]
        NoteDestroyed,

        [JsonPropertyName("order_created")]
        OrderCreated,

        [JsonPropertyName("payment_destroyed")]
        PaymentDestroyed,

        [JsonPropertyName("payment_linked_to_financial_mutation")]
        PaymentLinkedToFinancialMutation,

        [JsonPropertyName("payment_registered")]
        PaymentRegistered,

        [JsonPropertyName("payment_send_email")]
        PaymentSendEmail,

        [JsonPropertyName("payment_method_edited")]
        PaymentMethodEdited,

        [JsonPropertyName("payment_transaction_authorized")]
        PaymentTransactionAuthorized,

        [JsonPropertyName("payment_transaction_awaiting_authorization")]
        PaymentTransactionAwaitingAuthorization,

        [JsonPropertyName("payment_transaction_batch_cancelled")]
        PaymentTransactionBatchCancelled,

        [JsonPropertyName("payment_transaction_batch_created")]
        PaymentTransactionBatchCreated,

        [JsonPropertyName("payment_transaction_executing")]
        PaymentTransactionExecuting,

        [JsonPropertyName("payment_transaction_paid")]
        PaymentTransactionPaid,

        [JsonPropertyName("payment_transaction_pending")]
        PaymentTransactionPending,

        [JsonPropertyName("payment_transaction_rejected")]
        PaymentTransactionRejected,

        [JsonPropertyName("payment_transaction_technically_validated")]
        PaymentTransactionTechnicallyValidated,

        [JsonPropertyName("ponto_connected")]
        PontoConnected,

        [JsonPropertyName("ponto_disconnected")]
        PontoDisconnected,

        [JsonPropertyName("ponto_direct_bank_link_activated")]
        PontoDirectBankLinkActivated,

        [JsonPropertyName("ponto_direct_bank_link_expired")]
        PontoDirectBankLinkExpired,

        [JsonPropertyName("product_activated")]
        ProductActivated,

        [JsonPropertyName("product_created")]
        ProductCreated,

        [JsonPropertyName("product_deactivated")]
        ProductDeactivated,

        [JsonPropertyName("product_destroyed")]
        ProductDestroyed,

        [JsonPropertyName("product_updated")]
        ProductUpdated,

        [JsonPropertyName("project_activated")]
        ProjectActivated,

        [JsonPropertyName("project_created")]
        ProjectCreated,

        [JsonPropertyName("project_archived")]
        ProjectArchived,

        [JsonPropertyName("project_destroyed")]
        ProjectDestroyed,

        [JsonPropertyName("project_updated")]
        ProjectUpdated,

        [JsonPropertyName("purchase_transaction_added_to_batch")]
        PurchaseTransactionAddedToBatch,

        [JsonPropertyName("purchase_transaction_authorized")]
        PurchaseTransactionAuthorized,

        [JsonPropertyName("purchase_transaction_awaiting_authorization")]
        PurchaseTransactionAwaitingAuthorization,

        [JsonPropertyName("purchase_transaction_batch_cancelled")]
        PurchaseTransactionBatchCancelled,

        [JsonPropertyName("purchase_transaction_batch_created")]
        PurchaseTransactionBatchCreated,

        [JsonPropertyName("purchase_transaction_created")]
        PurchaseTransactionCreated,

        [JsonPropertyName("purchase_transaction_deleted")]
        PurchaseTransactionDeleted,

        [JsonPropertyName("purchase_transaction_executing")]
        PurchaseTransactionExecuting,

        [JsonPropertyName("purchase_transaction_paid")]
        PurchaseTransactionPaid,

        [JsonPropertyName("purchase_transaction_pending")]
        PurchaseTransactionPending,

        [JsonPropertyName("purchase_transaction_rejected")]
        PurchaseTransactionRejected,

        [JsonPropertyName("purchase_transaction_technically_validated")]
        PurchaseTransactionTechnicallyValidated,

        [JsonPropertyName("recurring_sales_invoice_auto_send_forcefully_disabled")]
        RecurringSalesInvoiceAutoSendForcefullyDisabled,

        [JsonPropertyName("recurring_sales_invoice_created")]
        RecurringSalesInvoiceCreated,

        [JsonPropertyName("recurring_sales_invoice_created_from_original")]
        RecurringSalesInvoiceCreatedFromOriginal,

        [JsonPropertyName("recurring_sales_invoice_created_from_original_recurring")]
        RecurringSalesInvoiceCreatedFromOriginalRecurring,

        [JsonPropertyName("recurring_sales_invoice_creating_skipped_due_to_limits")]
        RecurringSalesInvoiceCreatingSkippedDueToLimits,

        [JsonPropertyName("recurring_sales_invoice_deactivated")]
        RecurringSalesInvoiceDeactivated,

        [JsonPropertyName("recurring_sales_invoice_destroyed")]
        RecurringSalesInvoiceDestroyed,

        [JsonPropertyName("recurring_sales_invoice_invoice_created")]
        RecurringSalesInvoiceInvoiceCreated,

        [JsonPropertyName("recurring_sales_invoice_started_auto_send")]
        RecurringSalesInvoiceStartedAutoSend,

        [JsonPropertyName("recurring_sales_invoice_stopped_auto_send")]
        RecurringSalesInvoiceStoppedAutoSend,

        [JsonPropertyName("recurring_sales_invoice_updated")]
        RecurringSalesInvoiceUpdated,

        [JsonPropertyName("rule_activated")]
        RuleActivated,

        [JsonPropertyName("rule_updated")]
        RuleUpdated,

        [JsonPropertyName("rule_deactivated")]
        RuleDeactivated,

        [JsonPropertyName("rule_destroyed")]
        RuleDestroyed,
        
        [JsonPropertyName("sales_invoice_created")]
        SalesInvoiceCreated,

        [JsonPropertyName("sales_invoice_created_based_on_estimate")]
        SalesInvoiceCreatedBasedOnEstimate,

        [JsonPropertyName("sales_invoice_created_based_on_recurring")]
        SalesInvoiceCreatedBasedOnRecurring,

        [JsonPropertyName("sales_invoice_created_based_on_subscription")]
        SalesInvoiceCreatedBasedOnSubscription,

        [JsonPropertyName("sales_invoice_created_from_checkout_order")]
        SalesInvoiceCreatedFromCheckoutOrder,

        [JsonPropertyName("sales_invoice_created_from_original")]
        SalesInvoiceCreatedFromOriginal,

        [JsonPropertyName("sales_invoice_destroyed")]
        SalesInvoiceDestroyed,

        [JsonPropertyName("sales_invoice_marked_as_dubious")]
        SalesInvoiceMarkedAsDubious,

        [JsonPropertyName("sales_invoice_marked_as_uncollectible")]
        SalesInvoiceMarkedAsUncollectible,

        [JsonPropertyName("sales_invoice_merged")]
        SalesInvoiceMerged,

        [JsonPropertyName("sales_invoice_merged_with_recurring_sales_invoice")]
        SalesInvoiceMergedWithRecurringSalesInvoice,

        [JsonPropertyName("sales_invoice_paused")]
        SalesInvoicePaused,

        [JsonPropertyName("sales_invoice_revert_dubious")]
        SalesInvoiceRevertDubious,

        [JsonPropertyName("sales_invoice_revert_uncollectible")]
        SalesInvoiceRevertUncollectible,

        [JsonPropertyName("sales_invoice_send_email")]
        SalesInvoiceSendEmail,

        [JsonPropertyName("sales_invoice_send_manually")]
        SalesInvoiceSendManually,

        [JsonPropertyName("sales_invoice_send_post")]
        SalesInvoiceSendPost,

        [JsonPropertyName("sales_invoice_send_post_confirmation")]
        SalesInvoiceSendPostConfirmation,

        [JsonPropertyName("sales_invoice_send_post_cancelled")]
        SalesInvoiceSendPostCancelled,

        [JsonPropertyName("sales_invoice_send_reminder_email")]
        SalesInvoiceSendReminderEmail,

        [JsonPropertyName("sales_invoice_send_reminder_manually")]
        SalesInvoiceSendReminderManually,

        [JsonPropertyName("sales_invoice_send_reminder_post")]
        SalesInvoiceSendReminderPost,

        [JsonPropertyName("sales_invoice_send_reminder_post_confirmation")]
        SalesInvoiceSendReminderPostConfirmation,

        [JsonPropertyName("sales_invoice_send_si")]
        SalesInvoiceSendSi,

        [JsonPropertyName("sales_invoice_send_si_delivered")]
        SalesInvoiceSendSiDelivered,

        [JsonPropertyName("sales_invoice_send_si_error")]
        SalesInvoiceSendSiError,

        [JsonPropertyName("sales_invoice_send_to_payt")]
        SalesInvoiceSendToPayt,

        [JsonPropertyName("sales_invoice_state_changed_to_draft")]
        SalesInvoiceStateChangedToDraft,

        [JsonPropertyName("sales_invoice_state_changed_to_late")]
        SalesInvoiceStateChangedToLate,

        [JsonPropertyName("sales_invoice_state_changed_to_open")]
        SalesInvoiceStateChangedToOpen,

        [JsonPropertyName("sales_invoice_state_changed_to_paid")]
        SalesInvoiceStateChangedToPaid,

        [JsonPropertyName("sales_invoice_state_changed_to_pending_payment")]
        SalesInvoiceStateChangedToPendingPayment,

        [JsonPropertyName("sales_invoice_state_changed_to_reminded")]
        SalesInvoiceStateChangedToReminded,

        [JsonPropertyName("sales_invoice_state_changed_to_scheduled")]
        SalesInvoiceStateChangedToScheduled,

        [JsonPropertyName("sales_invoice_state_changed_to_uncollectible")]
        SalesInvoiceStateChangedToUncollectible,

        [JsonPropertyName("sales_invoice_unpaused")]
        SalesInvoiceUnpaused,

        [JsonPropertyName("sales_invoice_updated")]
        SalesInvoiceUpdated,

        [JsonPropertyName("send_payment_email")]
        SendPaymentEmail,

        [JsonPropertyName("send_payment_unsuccessful_email")]
        SendPaymentUnsuccessfulEmail,

        [JsonPropertyName("sepa_direct_debit_limit_updated")]
        SepaDirectDebitLimitUpdated,

        [JsonPropertyName("subgoal_assigned")]
        SubgoalAssigned,

        [JsonPropertyName("subgoal_completed")]
        SubgoalCompleted,

        [JsonPropertyName("subgoal_uncompleted")]
        SubgoalUncompleted,

        [JsonPropertyName("subscription_cancelled")]
        SubscriptionCancelled,

        [JsonPropertyName("subscription_created")]
        SubscriptionCreated,

        [JsonPropertyName("subscription_destroyed")]
        SubscriptionDestroyed,

        [JsonPropertyName("subscription_edited")]
        SubscriptionEdited,

        [JsonPropertyName("subscription_updated")]
        SubscriptionUpdated,

        [JsonPropertyName("tax_rate_activated")]
        TaxRateActivated,

        [JsonPropertyName("tax_rate_created")]
        TaxRateCreated,

        [JsonPropertyName("tax_rate_deactivated")]
        TaxRateDeactivated,

        [JsonPropertyName("tax_rate_destroyed")]
        TaxRateDestroyed,

        [JsonPropertyName("tax_rate_updated")]
        TaxRateUpdated,

        [JsonPropertyName("time_entry_created")]
        TimeEntryCreated,

        [JsonPropertyName("time_entry_destroyed")]
        TimeEntryDestroyed,

        [JsonPropertyName("time_entry_sales_invoice_created")]
        TimeEntrySalesInvoiceCreated,

        [JsonPropertyName("time_entry_updated")]
        TimeEntryUpdated,

        [JsonPropertyName("todo_completed")]
        TodoCompleted,

        [JsonPropertyName("todo_created")]
        TodoCreated,

        [JsonPropertyName("todo_destroyed")]
        TodoDestroyed,

        [JsonPropertyName("todo_opened")]
        TodoOpened,

        [JsonPropertyName("ultimate_beneficial_owner_verification_document_uploaded")]
        UltimateBeneficialOwnerVerificationDocumentUploaded,

        [JsonPropertyName("ultimate_benificial_owner_created")]
        UltimateBenificialOwnerCreated,

        [JsonPropertyName("ultimate_benificial_owner_updated")]
        UltimateBenificialOwnerUpdated,

        [JsonPropertyName("user_invited")]
        UserInvited,

        [JsonPropertyName("user_invited_for_call")]
        UserInvitedForCall,

        [JsonPropertyName("user_removed")]
        UserRemoved,

        [JsonPropertyName("vat_return_created")]
        VatReturnCreated,

        [JsonPropertyName("vat_return_received")]
        VatReturnReceived,

        [JsonPropertyName("vat_return_paid")]
        VatReturnPaid,

        [JsonPropertyName("vat_suppletion_created")]
        VatSuppletionCreated,

        [JsonPropertyName("vat_suppletion_received")]
        VatSuppletionReceived,

        [JsonPropertyName("vat_suppletion_paid")]
        VatSuppletionPaid,

        [JsonPropertyName("workflow_created")]
        WorkflowCreated,

        [JsonPropertyName("workflow_deactivated")]
        WorkflowDeactivated,

        [JsonPropertyName("workflow_destroyed")]
        WorkflowDestroyed,

        [JsonPropertyName("workflow_updated")]
        WorkflowUpdated
    }
}
