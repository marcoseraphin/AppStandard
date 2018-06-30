using System;
using System.Collections.Generic;
using AppStandard;
using AppStandard.Interfaces;
using FreshMvvm;

namespace AppStandard
{
    public class TranslationTables
    {
        /// <summary>
        /// The translation table.
        /// </summary>
        private static Dictionary<string, string> TranslationTable = new Dictionary<string, string>();

        /// <summary>
        /// Translate
        /// </summary>    
        public static string Translate(string elementName)
        {
            string result = "<TranslationNotFound>";

            string culture = "en-US"; // Default
            culture = App.Language == App.LanguageType.German ? "de-DE" : culture;

            if (TranslationTable.ContainsKey(culture + "#" + elementName) == true)
            {
                return TranslationTable[culture + "#" + elementName];
            }

            return result;
        }

        /// <summary>
        /// Inits the static values.
        /// </summary>
        public static void InitStaticValues()
        {
            // Sets the app language on device UI Language OR use saved DB language value
            SetAppLanguageOnDeviceUILanguageORLocalDBLanguageValue();

            bool translateTablesInDB = CheckTranslateTableInDB();
            translateTablesInDB = false; // During translation process set to false
            if (translateTablesInDB == false)
            {
                SetInitialValues();
                WriteTranslationTableToDB();
            }
            else
            {
                ReadTranslationTableFromDB();
            }

            // Set backend translation changes in memory dictionary and local DB
            GetTranslationChangesFromBackend();
        }

        /// <summary>
        /// Sets the initial values.
        /// </summary>
        public static void SetInitialValues()
        {
            TranslationTable.Clear();

            if (App.Language == App.LanguageType.German)
            {
                TranslationTable.Add("de-DE#" + "CaptionLabel", "Foto auswählen");                                

                // Login page
                TranslationTable.Add("de-DE#" + "LoginPageTitle", "ANMELDUNG");
                TranslationTable.Add("de-DE#" + "LoginUserName", "ANMELDENAME");
                TranslationTable.Add("de-DE#" + "LogInButton", "ANMELDEN");
                TranslationTable.Add("de-DE#" + "WelcomeLabel", "Willkommen");
                TranslationTable.Add("de-DE#" + "RegisterButton", "REGISTRIEREN");
                TranslationTable.Add("de-DE#" + "LogInButtonPlaceholder", "PASSWORT");
                TranslationTable.Add("de-DE#" + "ForgotPasswordButton", "PASSWORT VERGESSEN?");

                TranslationTable.Add("de-DE#" + "LoadingTextLoggingIn", "Anmeldung durchführen");
                TranslationTable.Add("de-DE#" + "MsgAlertErrorLogInTitle", "Fehler bei der Anmeldung");
                TranslationTable.Add("de-DE#" + "MsgAlertErrorLogIn", "Benutzername oder Kennwort falsch!");
                TranslationTable.Add("de-DE#" + "MsgAlertErrorLogInOnlineTitle", "Online Status");
                TranslationTable.Add("de-DE#" + "MsgAlertErrorLogInOnline", "Sie sind zur nicht mit einen Netzwerk (WLAN oder Mobil) verbunden!");
                TranslationTable.Add("de-DE#" + "MsgAlertLogInOffline", "Offline anmelden");
                TranslationTable.Add("de-DE#" + "MsgAlertLogInOfflineTitle", "Offline Anmeldung");
                TranslationTable.Add("de-DE#" + "MsgAlertLogInOfflineErroriOS", "Online Anmeldung leider nicht möglich, bitte TouchID verwenden");
                TranslationTable.Add("de-DE#" + "MsgAlertLogInOfflineErrorAndroid", "Online Anmeldung leider nicht möglich, bitte Offline PIN eingeben");
                TranslationTable.Add("de-DE#" + "ScanQRCodeButton", "QR-CODE REGISTRIERUNG");
                TranslationTable.Add("de-DE#" + "MsgAlertQRCodeTitle", "Gültigen QR-Code gefunden");
                TranslationTable.Add("de-DE#" + "MsgAlertQRCode", "Es wurden gültige QR-Code Daten gefunden! Bitte prüfen Sie die Registrierungs-Daten und klicken auf Registrieren");
                TranslationTable.Add("de-DE#" + "MsgAlertErrorQRCodeTitle", "Ungültiger QR-Code");
                TranslationTable.Add("de-DE#" + "MsgAlertQRCodeError", "Es wurde ein ungültiger QR-Code gefunden! Bitte prüfen!");
                TranslationTable.Add("de-DE#" + "MsgAlertLogInOfflineErrorWrongPIN", "Falsche PIN");
                TranslationTable.Add("de-DE#" + "MsgAlertLogInOnline", "Bitte per TouchID anmelden");

                // Master page
                TranslationTable.Add("de-DE#" + "MasterPage_Overview", "ÜBERSICHT");
                TranslationTable.Add("de-DE#" + "MasterPage_Policies", "POLICEN");
                TranslationTable.Add("de-DE#" + "MasterPage_ContactData", "KONTAKTDATEN");
                TranslationTable.Add("de-DE#" + "MasterPage_Introduction", "EINFÜHRUNG");
                TranslationTable.Add("de-DE#" + "MasterPage_Feedback", "FEEDBACK");
                TranslationTable.Add("de-DE#" + "MasterPage_Logout", "ABMELDEN");
                TranslationTable.Add("de-DE#" + "MasterPage_Menu", "MENÜ");
                TranslationTable.Add("de-DE#" + "MasterPage_Change", "ÄNDERUNG");
                TranslationTable.Add("de-DE#" + "MasterPage_Documents", "DOKUMENTE");
                TranslationTable.Add("de-DE#" + "MasterPage_Imprint", "DATENSCHUTZ");

                // Imprint page
                TranslationTable.Add("de-DE#" + "ImprintPageTitle", "Datenschutzerklärung");
                TranslationTable.Add("de-DE#" + "AonImprintLabel1", "Datenschutzerklärung der Aon Versicherungsmakler Deutschland GmbH");

                // Reset password page
                TranslationTable.Add("de-DE#" + "ResetPasswordTitle", "PASSWORT ZURÜCKSETZEN");
                TranslationTable.Add("de-DE#" + "ResetPasswordInfoTextLine1", "Bitte geben Sie ihre E-Mail Adresse");
                TranslationTable.Add("de-DE#" + "ResetPasswordInfoTextLine2", "ein. Anschließend erhalten Sie eine");
                TranslationTable.Add("de-DE#" + "ResetPasswordInfoTextLine3", "E-Mail mit einem Temporärpasswort.");
                TranslationTable.Add("de-DE#" + "RequestNewPasswordButton", "NEUES PASSWORT ANFORDERN");
                TranslationTable.Add("de-DE#" + "PasswordInValidText", "Bitte gültige E-Mail Adresse eintragen");
                TranslationTable.Add("de-DE#" + "PasswordValidText", "E-Mail Adresse gültig");
                TranslationTable.Add("de-DE#" + "YourEmailAddress", "IHRE E-MAIL ADRESSE");

                TranslationTable.Add("de-DE#" + "ResetPasswordInfoTextLine2_1", "Falls Sie bereits ein");
                TranslationTable.Add("de-DE#" + "ResetPasswordInfoTextLine2_2", "Temporärpasswort per E-Mail");
                TranslationTable.Add("de-DE#" + "ResetPasswordInfoTextLine2_3", "erhalten haben tippen Sie hier");
                TranslationTable.Add("de-DE#" + "CancelButton", "ABBRECHEN");
                TranslationTable.Add("de-DE#" + "LoadingTextResetPassword", "Ein neues Passwort wird angefordert");
                TranslationTable.Add("de-DE#" + "MsgAlertErrorResetPwdTitle", "Passwort zurück setzen");
                TranslationTable.Add("de-DE#" + "MsgAlertErrorResetPwd", "Ein neues Passwort ist erfolgreich erzeugt worden! Bitte prüfen Sie ihre EMail");
                TranslationTable.Add("de-DE#" + "MsgAlertErrorResetPwdError", "Es hat leider einen Fehler beim zurück Setzen des Passworts gegeben! Bitte versuchen Sie es erneut (Ihr aktuelles Passwort ist nicht verändert worden)");

                // Register page
                TranslationTable.Add("de-DE#" + "RegisterPageTitle", "REGISTRIERUNG");
                TranslationTable.Add("de-DE#" + "CompanyCodeEntryPlaceholder", "FIRMENCODE");
                TranslationTable.Add("de-DE#" + "RegisterInfoTextLine1", "Falls Sie bereits ein");
                TranslationTable.Add("de-DE#" + "RegisterInfoTextLine2", "Temporärpasswort per E-Mail");
                TranslationTable.Add("de-DE#" + "RegisterInfoTextLine3", "erhalten haben tippen Sie hier");
                TranslationTable.Add("de-DE#" + "LoadingTextRegister", "Registrierung wird durchgeführt");
                TranslationTable.Add("de-DE#" + "MsgAlertErrorRegisterTitle", "Registrierung");
                TranslationTable.Add("de-DE#" + "MsgAlertErrorRegister", "Die Registrierung ist erfolgreich durch geführt worden!");
                TranslationTable.Add("de-DE#" + "MsgAlertErrorRegisterError", "Es hat leider einen Fehler bei der Registrierung gegeben! Bitte versuchen Sie es erneut");
                TranslationTable.Add("de-DE#" + "PasswordLabel", "KENNWORT");
                TranslationTable.Add("de-DE#" + "MsgPasswordRulesTitle", "Registrierung NICHT möglich. Bitte beachten sie folgende Passwort-Regeln");

                // Intro pages
                TranslationTable.Add("de-DE#" + "NextIntroButton", "WEITER");
                TranslationTable.Add("de-DE#" + "CloseIntroButton", "SCHLIESSEN");
                TranslationTable.Add("de-DE#" + "IntroductionTitle", "EINFÜHRUNG");
                TranslationTable.Add("de-DE#" + "SkipIntroButtonText", "EINFÜHRUNG ÜBERSPRINGEN");

                // Change password page
                TranslationTable.Add("de-DE#" + "ChangePasswordTitle", "PASSWORT ÄNDERN");
                TranslationTable.Add("de-DE#" + "ChangePasswordInfoTextLine1", "* Die Länge des Passwortes ist festgelegt: 8-20 Zeichen");
                TranslationTable.Add("de-DE#" + "ChangePasswordInfoTextLine2", "* Es muss mindestens eine Ziffer 0-9 enthalten sein");
                TranslationTable.Add("de-DE#" + "ChangePasswordInfoTextLine3", "* Es muss mind. einen Buchstaben beider Schreibweisen");
                TranslationTable.Add("de-DE#" + "ChangePasswordInfoTextLine4", "  (Groß-/Kleinschreibung) enthalten sein");
                TranslationTable.Add("de-DE#" + "ChangePasswordInfoTextLine5", "* Folgende Sonderzeichen sind erlaubt:");
                TranslationTable.Add("de-DE#" + "ChangePasswordInfoTextLine6", "  Punkt (.), Bindestrich (-), Unterstrich (_), @-Zeichen");
                TranslationTable.Add("de-DE#" + "ChangePasswordInfoTextLine7", "  alle Umlaute (ä ö ü), ß-Zeichen, + Zeichen, #-Zeichen");
                TranslationTable.Add("de-DE#" + "ChangePasswordInfoTextLine8", "  !-Zeichen");
                TranslationTable.Add("de-DE#" + "ChangePasswordInfoTextLine9", "* Benutzername und Passwort dürfen nicht identisch sein");
                TranslationTable.Add("de-DE#" + "OldPasswortEntryPlaceHolder", "Altes Passwort");
                TranslationTable.Add("de-DE#" + "NewPasswortEntryPlaceHolder", "Neues Passwort");
                TranslationTable.Add("de-DE#" + "NewPasswortRepeatEntryPlaceHolder", "Neues Passwort (wiederholen)");
                TranslationTable.Add("de-DE#" + "ChangePasswordButton", "PASSWORT ÄNDERN");
                TranslationTable.Add("de-DE#" + "LoadingTextChangePassword", "Passwort wird geändert");
                TranslationTable.Add("de-DE#" + "MsgAlertResetPasswordTitle", "Kennwort Änderung");
                TranslationTable.Add("de-DE#" + "MsgAlertResetPassword", "Das Kennwort wurde erfolgreich geändert!");
                TranslationTable.Add("de-DE#" + "MsgAlertResetPasswordError", "Es hat leider einen Fehler bei der Kennwort Änderung gegeben! Bitte versuchen Sie es erneut (Ihr Kennwort wurde nicht geändert)");

                // Start page
                TranslationTable.Add("de-DE#" + "CustomerConsultantLabel", "IHR ANSPRECHPARTNER");
                TranslationTable.Add("de-DE#" + "CallbackLabel", "RÜCKRUF");
                TranslationTable.Add("de-DE#" + "SpecificCallbackLabel", "IHR RÜCKRUF");
                TranslationTable.Add("de-DE#" + "LastViewedPolicies", "ZULETZT ANGESEHENE POLICEN");
                TranslationTable.Add("de-DE#" + "NoCallbackPlaned", "Kein Rückruf geplant");
                TranslationTable.Add("de-DE#" + "CallButton", "ANRUFEN");
                TranslationTable.Add("de-DE#" + "MailButton", "E-MAIL");
                TranslationTable.Add("de-DE#" + "MsgTitelCall", "Anruf");
                TranslationTable.Add("de-DE#" + "MsgCallPart1", "Wollen Sie die Support Nummer ");
                TranslationTable.Add("de-DE#" + "MsgCallPart2", " anrufen ?");
                TranslationTable.Add("de-DE#" + "MsgCallAnswerYes", "Ja");
                TranslationTable.Add("de-DE#" + "MsgCallAnswerNo", "Nein");
                TranslationTable.Add("de-DE#" + "MsgCallError", "Zur Zeit kein Anruf möglich!");
                TranslationTable.Add("de-DE#" + "LoadingUserData", "Benutzerdaten laden");
                TranslationTable.Add("de-DE#" + "NoCustomerConsultantAvailable", "Keine Daten verfügbar");
                TranslationTable.Add("de-DE#" + "NotifyChangeButton", "ÄNDERUNG");

                // Feedback page
                TranslationTable.Add("de-DE#" + "CommentLabel", "Ihr Kommentar");
                TranslationTable.Add("de-DE#" + "CommentEntryPlaceholder", "Kommentar (optional)");
                TranslationTable.Add("de-DE#" + "RatingLabel", "WIE GEFÄLLT IHNEN DIE APP?");
                TranslationTable.Add("de-DE#" + "SendFeedbackButton", "FEEDBACK SENDEN");
                TranslationTable.Add("de-DE#" + "FeedbackInfoTextLine1", "Unsere Digital Broker App steckt");
                TranslationTable.Add("de-DE#" + "FeedbackInfoTextLine2", "noch in den Kinderschuhen - Helfen");
                TranslationTable.Add("de-DE#" + "FeedbackInfoTextLine3", "Sie uns gerne, indem Sie uns über");
                TranslationTable.Add("de-DE#" + "FeedbackInfoTextLine4", "nach Vertragsabschluss einige");
                TranslationTable.Add("de-DE#" + "FeedbackInfoTextLine5", "die Feedbackfunktion wissen lassen,");
                TranslationTable.Add("de-DE#" + "FeedbackInfoTextLine6", "was Ihnen gefällt und wo Sie sich");
                TranslationTable.Add("de-DE#" + "FeedbackInfoTextLine7", "noch Verbesserungen wünschen !");
                TranslationTable.Add("de-DE#" + "LoadingTextFeedback", "Feedback wird gesendet");
                TranslationTable.Add("de-DE#" + "MsgAlertErrorFeedback", "Ihr Feedback wurde erfolgreich versendet");
                TranslationTable.Add("de-DE#" + "MsgAlertErrorFeedbackError", "Es hat leider einen Fehler beim Versenden des Feedbacks gegeben! Bitte versuchen Sie es erneut");

                // Contact Data page
                TranslationTable.Add("de-DE#" + "ContactDataPageTitle", "KONTAKTDATEN");
                TranslationTable.Add("de-DE#" + "ContactDataLabel", "IHRE KONTAKTDATEN");
                TranslationTable.Add("de-DE#" + "ClientNumberLabel", "KUNDENNUMMER");
                TranslationTable.Add("de-DE#" + "DateOfBirthLabel", "GEBURTSDATUM");
                TranslationTable.Add("de-DE#" + "MobileNumberLabel", "TELEFON MOBIL");
                TranslationTable.Add("de-DE#" + "FirstNameLabel", "VORNAME");
                TranslationTable.Add("de-DE#" + "LastNameLabel", "NACHNAME");
                TranslationTable.Add("de-DE#" + "AddressLabel", "STRASSE / HAUSNUMMER");
                TranslationTable.Add("de-DE#" + "PostalCodeLabel", "POSTLEITZAHL");
                TranslationTable.Add("de-DE#" + "CityLabel", "ORT");
                TranslationTable.Add("de-DE#" + "PrivateEMailLabel", "E-MAIL PRIVAT");
                TranslationTable.Add("de-DE#" + "PrivateTelNrLabel", "TELEFONNUMMER PRIVAT");
                TranslationTable.Add("de-DE#" + "AlertTitle_ErrorReadingUserData", "Fehler beim Lesen der Benutzerdaten");
                TranslationTable.Add("de-DE#" + "AlertText_ErrorReadingUserData", "Die Benutzerinformationen konnten nicht gelesen werden");
                TranslationTable.Add("de-DE#" + "PreferredContactType", "Bevorzugte Kontaktart");
                TranslationTable.Add("de-DE#" + "TypeOfPreferredContact_Phone", "Telefon");
                TranslationTable.Add("de-DE#" + "TypeOfPreferredContact_EMail", "EMail");
                TranslationTable.Add("de-DE#" + "TypeOfPreferredContact_Postal", "Post");
                TranslationTable.Add("de-DE#" + "TypeOfPreferredContact_No", "Nicht ausgewählt");
                TranslationTable.Add("de-DE#" + "PickerMethodOfContactTitle", "Bevorzugte Kontaktart");
                TranslationTable.Add("de-DE#" + "SaveAndUploadContactData", "Kontaktdaten werden gespeichert");
                TranslationTable.Add("de-DE#" + "NoContactDataInfoText1", "Ihre Kontaktdaten werden zur Zeit überprüft.");
                TranslationTable.Add("de-DE#" + "MsgAlertContactDataUpload", "Kontaktdaten übermitteln");
                TranslationTable.Add("de-DE#" + "MsgAlertContactDataUploadSuccess", "Ihre Kontaktdaten wurden an Aon übermittelt. Es kann ggf. etwas dauern bis diese auch im System aktualisiert werden.");
                TranslationTable.Add("de-DE#" + "MsgAlertContactDataUploadError", "Ihre Kontaktdaten konnten nicht übermittelt werden. Bitte versuchen Sie, diese später erneut zu übermitteln!");
                TranslationTable.Add("de-DE#" + "SalutationTitle", "Anrede");
                TranslationTable.Add("de-DE#" + "SalutationMr", "Herr");
                TranslationTable.Add("de-DE#" + "SalutationMrs", "Frau");
                TranslationTable.Add("de-DE#" + "CountryLabel", "Land");
                TranslationTable.Add("de-DE#" + "HintBirthday18Years", "Mindestalter 18 Jahre");

                // Settings page
                TranslationTable.Add("de-DE#" + "SettingsPageTitle", "EINSTELLUNGEN");
                TranslationTable.Add("de-DE#" + "LanguageLabel", "SPRACHE");
                TranslationTable.Add("de-DE#" + "LanguageGermanLabel", "DEUTSCH");
                TranslationTable.Add("de-DE#" + "LanguageEnglishLabel", "ENGLISCH");
                TranslationTable.Add("de-DE#" + "SyncExternalPoliciesLabel", "Non-Aon Policen auch ohne WLAN synchronisieren");
                TranslationTable.Add("de-DE#" + "DeleteAccountButton", "KONTO LÖSCHEN");
                TranslationTable.Add("de-DE#" + "LoadingTextSwitchingLanguageToGerman", "Die Sprache wird auf Deutsch umgestellt");
                TranslationTable.Add("de-DE#" + "LoadingTextSwitchingLanguageToEnglish", "Die Sprache wird auf Englisch umgestellt");
                TranslationTable.Add("de-DE#" + "OfflinePINLabel", "Offline PIN Anmeldung");
                TranslationTable.Add("de-DE#" + "MsgDeletedAccount", "Ihr Account wird in Kürze gelöscht");
                TranslationTable.Add("de-DE#" + "UseTouchIDLabel", "TouchID für Anmeldung nutzen");

                // Policies page             
                TranslationTable.Add("de-DE#" + "PoliciesPageTitle", "POLICEN");
                TranslationTable.Add("de-DE#" + "NoPoliciesInfoText1", "Für diesen Account sind momentan keine Policen");
                TranslationTable.Add("de-DE#" + "NoPoliciesInfoText2", "hinterlegt. Bitte beachten Sie, dass es nach");
                TranslationTable.Add("de-DE#" + "NoPoliciesInfoText3", "Registrierung oder Abschluss neuer Verträge");
                TranslationTable.Add("de-DE#" + "NoPoliciesInfoText4", "einige Tage dauern kann, bis Policen in der App");
                TranslationTable.Add("de-DE#" + "NoPoliciesInfoText5", "sichtbar sind. Um den Prozess zu beschleunigen");
                TranslationTable.Add("de-DE#" + "NoPoliciesInfoText6", "geben Sie bitte stets die gleiche EMail-Adresse an.");
                TranslationTable.Add("de-DE#" + "NoPoliciesInfoText7", "");
                TranslationTable.Add("de-DE#" + "NoPoliciesInfoText8", "Es sind keine Policen hinterlegt.");
                TranslationTable.Add("de-DE#" + "NoPoliciesInfoText9", "Sind Ihre Verträge und unvollständig oder feherhaft,");
                TranslationTable.Add("de-DE#" + "NoPoliciesInfoText10", "so klicken Sie hier.");
                TranslationTable.Add("de-DE#" + "CheckPoliciesButton", "Prüfen");


                // Documents page
                TranslationTable.Add("de-DE#" + "DocumentsPageTitle", "DOKUMENTE");
                TranslationTable.Add("de-DE#" + "NonAonPolicies", "NON-AON POLICEN");
                TranslationTable.Add("de-DE#" + "NoNonAonPoliciesInfoText", "Sie haben noch keine Non-Aon Policen angelegt.");
                TranslationTable.Add("de-DE#" + "NewNonAonPolicyButton", "NEUE NON-AON POLICE");

                TranslationTable.Add("de-DE#" + "MsgAlertOffline", "Offline Status");
                TranslationTable.Add("de-DE#" + "MsgAlertOfflineError", "Sie sind zur Zeit nicht online, daher steht momentan der Zugriff auf diese Daten nicht zur Verfügung! Bitte erneut aufrufen, wenn Sie online sind!");
                TranslationTable.Add("de-DE#" + "DeleteNonAonPoliciesContextMenu", "Löschen");
                TranslationTable.Add("de-DE#" + "MsgTitelDeletePolicy", "Non-Aon Police löschen");
                TranslationTable.Add("de-DE#" + "MsgDeletePolicyText", "Wollen Sie diese Non-Aon Police löschen ?");

                // New Non-Aon policy
                TranslationTable.Add("de-DE#" + "NewNonAonPolicy", "NEUE NON-AON POLICE");
                TranslationTable.Add("de-DE#" + "CreateNewNonAonPolicyButton", "MIT DETAILS ANLEGEN");
                TranslationTable.Add("de-DE#" + "CreateNewNonAonPolicyWithoutDetailsButton", "OHNE DETAILS ANLEGEN");
                TranslationTable.Add("de-DE#" + "CategoryLabel", "SPARTE");
                TranslationTable.Add("de-DE#" + "LoadingTextLoadingPolicies", "Policen werden abgerufen");
                TranslationTable.Add("de-DE#" + "LoadingTextLoadingNonAonPolicies", "Non-Aon Policen werden abgerufen");
                TranslationTable.Add("de-DE#" + "LoadingTextCreatingNonAonPolicy", "Police anlegen");
                TranslationTable.Add("de-DE#" + "LoadingTextSavingNonAonPolicy", "Police speichern");
                TranslationTable.Add("de-DE#" + "MsgAlertResult", "Ergebnis");
                TranslationTable.Add("de-DE#" + "MsgAlertNonAonPolicyCreated", "Die Police ist erfolgreich auf Ihrem Gerät angelegt worden! Bitte führen Sie den Upload inkl. Fotos durch, wenn gewünscht");
                TranslationTable.Add("de-DE#" + "MsgAlertNonAonPolicySaved", "Die Police ist erfolgreich auf Ihrem Gerät gespeichert worden!");
                TranslationTable.Add("de-DE#" + "MsgAlertSystemError", "Es ist leider ein Systemfehler beim Lesen der Policen aufgetreten");
                TranslationTable.Add("de-DE#" + "MsgAlertSystemErrorNonAon", "Es ist leider ein Systemfehler beim Lesen der Non-Aon Policen aufgetreten");
                TranslationTable.Add("de-DE#" + "MsgAlertSystemErrorNonAonCreate", "Es ist ein Systemfehler beim Anlegen der Non-Aon Police aufgetreten");
                TranslationTable.Add("de-DE#" + "MsgAlertNoCameraTitle", "Kamera");
                TranslationTable.Add("de-DE#" + "MsgAlertNoCamera", "Kein Kamera verfügbar");
                TranslationTable.Add("de-DE#" + "PickerPolicyType", "Policen-Type wählen");
                TranslationTable.Add("de-DE#" + "PolicyTypeLabel", "Policen Typ:");
                TranslationTable.Add("de-DE#" + "PickerMethodOfPaymentTitle", "wählen");
                TranslationTable.Add("de-DE#" + "PolicyCommentLabel", "IHR KOMMENTAR");
                TranslationTable.Add("de-DE#" + "PolicySubjectLabel", "BETREFF");
                TranslationTable.Add("de-DE#" + "LoadingTextUploadingNonAonPolicyImages", "Policendaten und Fotos werden hochgeladen");
                TranslationTable.Add("de-DE#" + "MsgAlertFotoUpload", "Upload Status");
                TranslationTable.Add("de-DE#" + "MsgAlertFotoUploadError", "Es konnten nicht alle Daten und  Fotos hochgeladen werden! Bitte wiederholen Sie den Vorgang");
                TranslationTable.Add("de-DE#" + "MsgAlertFotoUploadSuccess", "Ihre Vertragsdaten wurden an Aon übermittelt. Sie erhalten in Kürze weitere Informationen per E-Mail.");
                TranslationTable.Add("de-DE#" + "MsgTitelUpload", "Rechtliche Hinweise");
                TranslationTable.Add("de-DE#" + "MsgUploadLegalText", "Mit der Übermittlung der von Ihnen eingegebenen Daten und/oder Verträge und/oder Fotos übernimmt Aon keine Haftung für Vollständigkeit und Richtigkeit der übermittelten Daten. Die reine Übermittlung Ihrer Vertragsdaten stellt noch keine Beauftragung zur Durchführung von Maklertätigkeiten durch Aon dar.");
                TranslationTable.Add("de-DE#" + "MsgUploadLegalText2", "Sofern Sie an einer Überprüfung des übermittelten Vertrages interessiert sind und ein Vergleichsangebot wünschen, bestätigen Sie dies bitte mit Akzeptieren. Bitte beachten Sie, dass dies einen gültigen Maklerauftrag zwischen Ihnen und Aon erfordert. Sollte dies nicht vorhanden sein oder der Maklerauftrag erweitert werden müssen, erhalten Sie die nötigen Dokumente mit separater Email und Aon wird vor der offiziellen Beauftragung nicht aktiv werden.");
                TranslationTable.Add("de-DE#" + "MsgUploadLegalTextCancel", "Ihre Vertragsdaten wurden nicht an Aon übermittelt. Die von Ihnen eingegebenen Daten wurden lokal auf Ihrem Gerät gespeichert.");
                TranslationTable.Add("de-DE#" + "LoadingTextProcessingFoto", "Foto wird verarbeitet");

                TranslationTable.Add("de-DE#" + "PickerNonAonPolicy_Motor", "KRAFTFAHRZEUG");
                TranslationTable.Add("de-DE#" + "PickerNonAonPolicy_ResidentialBuilding", "WOHNGEBÄUDE");
                TranslationTable.Add("de-DE#" + "PickerNonAonPolicy_Liability", "HAFTPFLICHT");
                TranslationTable.Add("de-DE#" + "PickerNonAonPolicy_Household", "HAUSRAT");
                TranslationTable.Add("de-DE#" + "PickerNonAonPolicy_Accident", "UNFALL");
                TranslationTable.Add("de-DE#" + "PickerNonAonPolicy_PrivateHealth", "KRANKENZUSATZ");
                TranslationTable.Add("de-DE#" + "PickerNonAonPolicy_LegalCosts", "RECHTSCHUTZ");
                TranslationTable.Add("de-DE#" + "PickerNonAonPolicy_LifeInsurance", "LEBENSVERSICHERUNG");
                TranslationTable.Add("de-DE#" + "PickerNonAonPolicy_Generic", "SONSTIGE");
                TranslationTable.Add("de-DE#" + "SaveLocalButton", "POLICE LOKAL SPEICHERN");
                TranslationTable.Add("de-DE#" + "DeleteButton", "POLICE LÖSCHEN");
                TranslationTable.Add("de-DE#" + "MsgCallAnswerOk", "Ok");
                TranslationTable.Add("de-DE#" + "MsgCallAnswerAccept", "Akzeptieren");
                TranslationTable.Add("de-DE#" + "MsgCallAnswerNotAccept", "NICHT Akzeptieren");

                // Callback page
                TranslationTable.Add("de-DE#" + "CallbackPageTitle", "RÜCKRUF");
                TranslationTable.Add("de-DE#" + "CallbackCommentPlaceHolder", "Ihr Kommentar (optional)");
                TranslationTable.Add("de-DE#" + "CallbackTelNrPlaceHolder", "Ihre Telefonnummer");
                TranslationTable.Add("de-DE#" + "CallbackButton", "RÜCKRUF ANLEGEN");
                TranslationTable.Add("de-DE#" + "CallbackPage_Today", "Heute");
                TranslationTable.Add("de-DE#" + "CallbackPage_Between", "Zwischen");
                TranslationTable.Add("de-DE#" + "CallbackPage_And", "und");
                TranslationTable.Add("de-DE#" + "CallbackPage_Clock", "Uhr");
                TranslationTable.Add("de-DE#" + "CallbackPage_Day", "Tag");
                TranslationTable.Add("de-DE#" + "MsgAlertSystemErrorSendingCallback", "Es ist leider ein Systemfehler beim Anlegen des Rückrufs aufgetreten");
                TranslationTable.Add("de-DE#" + "MsgAlertSendingCallback", "Der Rückruf ist erfolgreich im System angelegt worden!");
                TranslationTable.Add("de-DE#" + "LoadingTextSendingCallback", "Rückruf wird angelegt");

                // Policies detail page
                TranslationTable.Add("de-DE#" + "PoliciesDetailsPageTitle", "POLICENDETAILS");
                TranslationTable.Add("de-DE#" + "PolicyContractLabel", "VERTRAGSNUMMER *");
                TranslationTable.Add("de-DE#" + "PolicyInsurerLabel", "VERSICHERER *");
                TranslationTable.Add("de-DE#" + "PolicyAnnualBonusLabel", "JAHRESPRÄMIE *");
                TranslationTable.Add("de-DE#" + "PolicyPeriodLabel", "ZEITRAUM");
                TranslationTable.Add("de-DE#" + "PolicyMethodOfPaymentLabel", "ZAHLWEISE");
                TranslationTable.Add("de-DE#" + "PolicyDueDateLabel", "FÄLLIGKEITSDATUM");
                TranslationTable.Add("de-DE#" + "PolicyDetail_Payment_Yearly", "JÄHRLICH");
                TranslationTable.Add("de-DE#" + "PolicyDetail_Payment_HalfYearly", "HALBJÄHRLICH");
                TranslationTable.Add("de-DE#" + "PolicyDetail_Payment_Monthly", "MONATLICH");
                TranslationTable.Add("de-DE#" + "PolicyDetail_Payment_Quarter", "QUARTALSWEISE");
                TranslationTable.Add("de-DE#" + "PolicyDetail_CoverageType_FullyComprehensive", "VOLLKASKO");
                TranslationTable.Add("de-DE#" + "PolicyDetail_CoverageType_DamageWaiver", "TEILKASKO");
                TranslationTable.Add("de-DE#" + "FotoListHeaderLabel", "AUFNAHMEN");


                TranslationTable.Add("de-DE#" + "PolicyType_Motor", "KRAFTFAHRZEUG");
                TranslationTable.Add("de-DE#" + "PolicyType_ResidentialBuilding", "WOHNGEBÄUDE");
                TranslationTable.Add("de-DE#" + "PolicyType_Liability", "HAFTPFLICHT");
                TranslationTable.Add("de-DE#" + "PolicyType_Household", "HAUSRAT");
                TranslationTable.Add("de-DE#" + "PolicyType_Casuality", "UNFALL");
                TranslationTable.Add("de-DE#" + "PolicyType_PrivateHealth", "KRANKENZUSATZ");
                TranslationTable.Add("de-DE#" + "PolicyType_LegalCosts", "RECHTSCHUTZ");
                TranslationTable.Add("de-DE#" + "PolicyType_LifeInsurance", "LEBENSVERSICHERUNG");
                TranslationTable.Add("de-DE#" + "PolicyType_Generic", "SONSTIGE");

                TranslationTable.Add("de-DE#" + "UploadImagesButton", "POLICE AN AON ÜBERMITTELN");


                // Extra Fields for Vehicle Policy
                TranslationTable.Add("de-DE#" + "PolicyLicensePlateLabel", "KENNZEICHEN");
                TranslationTable.Add("de-DE#" + "PolicyBrandModelLabel", "HERSTELLER / MODELL");
                TranslationTable.Add("de-DE#" + "PolicyCoverageTypeLabel", "DECKUNG");
                TranslationTable.Add("de-DE#" + "PolicyHarmFreedomClassLabel", "SCHADENFREIHEITSKLASSE");

                // Extra Fields for ResidentialBuilding Policy
                TranslationTable.Add("de-DE#" + "PolicyCoverageAmountLabel", "VERSICHERUNGSSUMME");
                TranslationTable.Add("de-DE#" + "PolicyInsuredRiskLabel", "VERSICHERTES RISIKO");
                TranslationTable.Add("de-DE#" + "PolicyValueLabel", "WERT");
                TranslationTable.Add("de-DE#" + "PolicySizeInSMLabel", "WOHNFLÄCHE IN m²");
                TranslationTable.Add("de-DE#" + "PolicyPerilsLabel", "FEUER / LEITUNGSWASSER / HAGEL");
                TranslationTable.Add("de-DE#" + "PolicyNaturalHazardsLabel", "ELEMENTARGEFAHREN");

                // Extra Fields for Liability Policy
                TranslationTable.Add("de-DE#" + "PolicyFlatOrCombinationLabel", "FlatOrCombination");
                TranslationTable.Add("de-DE#" + "PolicyDamagaToFinanceLabel", "FINANZSCHÄDEN");
                TranslationTable.Add("de-DE#" + "PolicyDamagaToPersonsLabel", "PERSONENSCHÄDEN");
                TranslationTable.Add("de-DE#" + "PolicyDamagaToPropertyLabel", "SACHSCHÄDEN");

                // Extra Fields for HouseHold Policy
                TranslationTable.Add("de-DE#" + "PolicyLivingSpaceLabel", "WOHNFLÄCHE");

                // Extra Fields for Casuality Policy
                TranslationTable.Add("de-DE#" + "PolicyDisabilityInsuredAmountLabel", "INVALIDITÄTSSUMME");
                TranslationTable.Add("de-DE#" + "PolicyProgressionLabel", "PROGRESSION");
                TranslationTable.Add("de-DE#" + "PolicyPayableAtDeathLabel", "TODESFALLSUMME");

                // Non-Aon Policy Vehicle
                TranslationTable.Add("de-DE#" + "NonAonPolicyVehiclePageTitel", "Non-Aon Kraftfahrzeug Police");
                TranslationTable.Add("de-DE#" + "ValidFromLabel", "GÜLTIG AB");
                TranslationTable.Add("de-DE#" + "ValidToLabel", "GÜLTIG BIS");
                TranslationTable.Add("de-DE#" + "CreateButton", "ANLEGEN");
                TranslationTable.Add("de-DE#" + "SaveButton", "SPEICHERN");
                TranslationTable.Add("de-DE#" + "PolicyFotoButton", "POLICE FOTOGRAFIEREN");

                // Non-Aon Policy Residentaial Building 
                TranslationTable.Add("de-DE#" + "NonAonPolicyResidentialBuildingPageTitel", "Non-Aon Wohngebäude Police");

                // Non-Aon Policy Liability 
                TranslationTable.Add("de-DE#" + "NonAonPolicyLiabilityPageTitel", "Non-Aon Haftpflicht Police");

                // Non-Aon Policy Household 
                TranslationTable.Add("de-DE#" + "NonAonPolicyHouseholdPageTitel", "Non-Aon Hausrat Police");

                // Non-Aon Policy Casuality 
                TranslationTable.Add("de-DE#" + "NonAonPolicyCasualityPageTitel", "Non-Aon Unfall Police");

                // Non-Aon Policy PrivateHealth 
                TranslationTable.Add("de-DE#" + "NonAonPolicyPrivateHealthPageTitel", "Non-Aon Krankenzusatz Police");

                // Non-Aon Policy LegalCosts 
                TranslationTable.Add("de-DE#" + "NonAonPolicyLegalCostsPageTitel", "Non-Aon Rechtschutz Police");

                // Non-Aon Policy LifeInsurance 
                TranslationTable.Add("de-DE#" + "NonAonPolicyLifeInsurancePageTitel", "Non-Aon Lebensversicherung Police");

                // Non-Aon Policy Generic 
                TranslationTable.Add("de-DE#" + "NonAonPolicyGenricPageTitel", "Non-Aon Sonstige Police");

                // Notify change Page
                TranslationTable.Add("de-DE#" + "NotifyChangePageTitel", "ÄNDERUNG MELDEN");
                TranslationTable.Add("de-DE#" + "ReasonLabel", "GRUND");
                TranslationTable.Add("de-DE#" + "NotifyButton", "ÄNDERUNG SENDEN");
                TranslationTable.Add("de-DE#" + "NotifyReasonType", "ÄNDERUNGSGRUND AUSWÄHLEN");
                TranslationTable.Add("de-DE#" + "PickerNotifyReason_WrongLegacyData", "Kontaktdaten ändern");
                TranslationTable.Add("de-DE#" + "PickerNotifyReason_WrongPolicyData", "Fehler in Police");
                TranslationTable.Add("de-DE#" + "PickerNotifyReason_MissingPolicy", "Police fehlt");
                TranslationTable.Add("de-DE#" + "PickerNotifyReason_OtherReason", "Sonstiges");
                TranslationTable.Add("de-DE#" + "WrongPolicyPickerTitel", "Bitte falsche Police auswählen");
                TranslationTable.Add("de-DE#" + "LoadingTextSendingNotification", "Meldung wird gesendet");
                TranslationTable.Add("de-DE#" + "MsgAlertErrorSendingNotification", "Es ist ein Fehler beim Senden der Meldung aufgetreten");
                TranslationTable.Add("de-DE#" + "NotifyCommentLabel", "IHR KOMMENTAR");
                TranslationTable.Add("de-DE#" + "MsgAlertSuccessSendingNotification", "Die Änderungs-Meldung ist erfolgreich versendet worden");

                // New external policy image big page
                TranslationTable.Add("de-DE#" + "DeleteImageButton", "FOTO LÖSCHEN");
                TranslationTable.Add("de-DE#" + "NoFotoButton", "OHNE FOTO FORTFAHREN");
                TranslationTable.Add("de-DE#" + "WithFotoButton", "MIT DIESEN FOTOS FORTFAHREN");
                TranslationTable.Add("de-DE#" + "MakeNewNonAonPolicyFotosLabel", "Fotografieren Sie Ihre Police wenn gewünscht und möglich");

                // Connectivity Status (Toolbar)
                TranslationTable.Add("de-DE#" + "MsgAlertConnectivityTitle", "Verbindungsstatus");
                TranslationTable.Add("de-DE#" + "MsgAlertConnectivityOffline", "Sie sind zur Zeit Offline");
                TranslationTable.Add("de-DE#" + "MsgAlertConnectivityOnline", "Sie sind zur Zeit Online");

            }

            if (App.Language == App.LanguageType.English)
            {
                TranslationTable.Add("en-US#" + "CaptionLabel", "Pick a Foto");                                

                // Login page
                TranslationTable.Add("en-US#" + "LoginPageTitle", "LOGIN");
                TranslationTable.Add("en-US#" + "LoginUserName", "USERNAME");
                TranslationTable.Add("en-US#" + "LogInButton", "LOGIN");
                TranslationTable.Add("en-US#" + "WelcomeLabel", "Welcome");
                TranslationTable.Add("en-US#" + "RegisterButton", "REGISTER");
                TranslationTable.Add("en-US#" + "LogInButtonPlaceholder", "PASSWORD");
                TranslationTable.Add("en-US#" + "ForgotPasswordButton", "FORGOT PASSWORD?");
                TranslationTable.Add("en-US#" + "LoadingTextLoggingIn", "Processing Login");
                TranslationTable.Add("en-US#" + "MsgAlertErrorLogInTitle", "Login error");
                TranslationTable.Add("en-US#" + "MsgAlertErrorLogIn", "User name or password not correct!");
                TranslationTable.Add("en-US#" + "MsgAlertErrorLogInOnlineTitle", "Online Status");
                TranslationTable.Add("en-US#" + "MsgAlertErrorLogInOnline", "You are currently not connected to an network (WLAN or Mobile)!");
                TranslationTable.Add("en-US#" + "MsgAlertLogInOffline", "Offline Login");
                TranslationTable.Add("en-US#" + "MsgAlertLogInOfflineTitle", "Offline Login");
                TranslationTable.Add("en-US#" + "MsgAlertLogInOfflineErroriOS", "Online Login not possible. Please use TouchID");
                TranslationTable.Add("en-US#" + "MsgAlertLogInOfflineErrorAndroid", "Online Login not possible. Please enter offline PIN");
                TranslationTable.Add("en-US#" + "ScanQRCodeButton", "QR-CODE REGISTRATION");
                TranslationTable.Add("en-US#" + "MsgAlertQRCodeTitle", "Found valid QR-Code");
                TranslationTable.Add("en-US#" + "MsgAlertQRCode", "Found valid QR-Code data! Please check your registration data and click register");
                TranslationTable.Add("en-US#" + "MsgAlertErrorQRCodeTitle", "Invalid QR-Code");
                TranslationTable.Add("en-US#" + "MsgAlertQRCodeError", "Found invalid QR-Code! Please check!");
                TranslationTable.Add("en-US#" + "MsgAlertLogInOfflineErrorWrongPIN", "Wrong PIN");
                TranslationTable.Add("en-US#" + "MsgAlertLogInOnline", "Please login using TouchID");

                // Master page
                TranslationTable.Add("en-US#" + "MasterPage_Overview", "OVERVIEW");
                TranslationTable.Add("en-US#" + "MasterPage_Policies", "POLICIES");
                TranslationTable.Add("en-US#" + "MasterPage_ContactData", "CONTACT DATA");
                TranslationTable.Add("en-US#" + "MasterPage_Introduction", "WALKTHROUGH");
                TranslationTable.Add("en-US#" + "MasterPage_Feedback", "FEEDBACK");
                TranslationTable.Add("en-US#" + "MasterPage_Logout", "LOGOUT");
                TranslationTable.Add("en-US#" + "MasterPage_Menu", "MENU");
                TranslationTable.Add("en-US#" + "MasterPage_Change", "CHANGE");
                TranslationTable.Add("en-US#" + "MasterPage_Documents", "DOCUMENTS");
                TranslationTable.Add("en-US#" + "MasterPage_Imprint", "PRIVACY POLICY");

                // Imprint page
                TranslationTable.Add("en-US#" + "ImprintPageTitle", "Privacy Policy");
                TranslationTable.Add("en-US#" + "AonImprintLabel1", "Data protection of Aon Versicherungsmakler Deutschland GmbH");

                // Reset password page
                TranslationTable.Add("en-US#" + "ResetPasswordTitle", "PASSWORD RESET");
                TranslationTable.Add("en-US#" + "ResetPasswordInfoTextLine1", "Please enter your E-Mail address.");
                TranslationTable.Add("en-US#" + "ResetPasswordInfoTextLine2", "After that you will receive an E-Mail");
                TranslationTable.Add("en-US#" + "ResetPasswordInfoTextLine3", "with a temporary password.");
                TranslationTable.Add("en-US#" + "RequestNewPasswordButton", "REQUEST NEW PASSWORD");
                TranslationTable.Add("en-US#" + "PasswordInValidText", "Please enter a valid E-Mail address");
                TranslationTable.Add("en-US#" + "PasswordValidText", "E-Mail address valid");
                TranslationTable.Add("en-US#" + "ResetPasswordInfoTextLine2_1", "If you have already received a");
                TranslationTable.Add("en-US#" + "ResetPasswordInfoTextLine2_2", "temporary password tap here");
                TranslationTable.Add("en-US#" + "ResetPasswordInfoTextLine2_3", "");
                TranslationTable.Add("en-US#" + "CancelButton", "CANCEL");
                TranslationTable.Add("en-US#" + "LoadingTextResetPassword", "A new password was requested");
                TranslationTable.Add("en-US#" + "MsgAlertErrorResetPwdTitle", "Reset password");
                TranslationTable.Add("en-US#" + "MsgAlertErrorResetPwd", "A new password was generated successfully! Please check your eMail");
                TranslationTable.Add("en-US#" + "MsgAlertErrorResetPwdError", "An error occured resetting the password! Please try again (your current password was not changed)");
                TranslationTable.Add("en-US#" + "YourEmailAddress", "YOUR E-MAIL ADDRESS");

                // Register page
                TranslationTable.Add("en-US#" + "RegisterPageTitle", "REGISTRATION");
                TranslationTable.Add("en-US#" + "CompanyCodeEntryPlaceholder", "COMPANYCODE");
                TranslationTable.Add("en-US#" + "RegisterInfoTextLine1", "If you have already received");
                TranslationTable.Add("en-US#" + "RegisterInfoTextLine2", "a temporary password tap here");
                TranslationTable.Add("en-US#" + "RegisterInfoTextLine3", "");
                TranslationTable.Add("en-US#" + "LoadingTextRegister", "Processing Registration");
                TranslationTable.Add("en-US#" + "MsgAlertErrorRegisterTitle", "Registration");
                TranslationTable.Add("en-US#" + "MsgAlertErrorRegister", "The Registration was successfull!");
                TranslationTable.Add("en-US#" + "MsgAlertErrorRegisterError", "The Registration was unsuccessfull! Please try again");
                TranslationTable.Add("en-US#" + "PasswordLabel", "PASSWORD");
                TranslationTable.Add("en-US#" + "MsgPasswordRulesTitle", "Registration NOT possible. Please observe the following password rules");

                // Intro pages
                TranslationTable.Add("en-US#" + "NextIntroButton", "NEXT");
                TranslationTable.Add("en-US#" + "CloseIntroButton", "CLOSE");
                TranslationTable.Add("en-US#" + "IntroductionTitle", "INTRODUCTION");
                TranslationTable.Add("en-US#" + "SkipIntroButtonText", "SKIP INTRODUCTION");

                // Change password page
                TranslationTable.Add("en-US#" + "ChangePasswordTitle", "CHANGE PASSWORD");
                TranslationTable.Add("en-US#" + "ChangePasswordInfoTextLine1", "* The length of the password is fixed: 8-20 characters");
                TranslationTable.Add("en-US#" + "ChangePasswordInfoTextLine2", "* There must be at least one digit 0-9");
                TranslationTable.Add("en-US#" + "ChangePasswordInfoTextLine3", "* It must contain at least one letter of both spellings");
                TranslationTable.Add("en-US#" + "ChangePasswordInfoTextLine4", "  (Uppercase and lowercase)");
                TranslationTable.Add("en-US#" + "ChangePasswordInfoTextLine5", "* The following special characters are allowed:");
                TranslationTable.Add("en-US#" + "ChangePasswordInfoTextLine6", "  Dot (.), Hyphen (-), underscore (_), @ sign");
                TranslationTable.Add("en-US#" + "ChangePasswordInfoTextLine7", "  all umlauts (ä ö ü), ß-sign, + sign, #-character");
                TranslationTable.Add("en-US#" + "ChangePasswordInfoTextLine8", "  !-character");
                TranslationTable.Add("en-US#" + "ChangePasswordInfoTextLine9", "* Username and password can not be the same");
                TranslationTable.Add("en-US#" + "OldPasswortEntryPlaceHolder", "Old Password");
                TranslationTable.Add("en-US#" + "NewPasswortEntryPlaceHolder", "New Password");
                TranslationTable.Add("en-US#" + "NewPasswortRepeatEntryPlaceHolder", "Repeat new Password");
                TranslationTable.Add("en-US#" + "ChangePasswordButton", "CHANGE PASSWORD");
                TranslationTable.Add("en-US#" + "LoadingTextChangePassword", "Changing password");
                TranslationTable.Add("en-US#" + "MsgAlertResetPasswordTitle", "Password change");
                TranslationTable.Add("en-US#" + "MsgAlertResetPassword", "The password was changed successfully!");
                TranslationTable.Add("en-US#" + "MsgAlertResetPasswordError", "Changing the password was unsuccessfull! Please try again (Your password was not changed)");

                // Start page
                TranslationTable.Add("en-US#" + "CustomerConsultantLabel", "YOUR CONTACT");
                TranslationTable.Add("en-US#" + "CallbackLabel", "CALLBACK");
                TranslationTable.Add("en-US#" + "SpecificCallbackLabel", "Your Callback");
                TranslationTable.Add("en-US#" + "LastViewedPolicies", "LAST VIEWED POLICIES");
                TranslationTable.Add("en-US#" + "NoCallbackPlaned", "No Callback planed");
                TranslationTable.Add("en-US#" + "CallButton", "CALL");
                TranslationTable.Add("en-US#" + "MailButton", "E-MAIL");
                TranslationTable.Add("en-US#" + "MsgTitelCall", "Call");
                TranslationTable.Add("en-US#" + "MsgCallPart1", "Call Support Number ");
                TranslationTable.Add("en-US#" + "MsgCallPart2", " ?");
                TranslationTable.Add("en-US#" + "MsgCallAnswerYes", "Yes");
                TranslationTable.Add("en-US#" + "MsgCallAnswerNo", "No");
                TranslationTable.Add("en-US#" + "MsgCallError", "Currently no call possible!");
                TranslationTable.Add("en-US#" + "LoadingUserData", "Loading user data");
                TranslationTable.Add("en-US#" + "NoCustomerConsultantAvailable", "No data available");
                TranslationTable.Add("en-US#" + "NotifyChangeButton", "CHANGE");

                // Feedback page
                TranslationTable.Add("en-US#" + "CommentLabel", "YOUR COMMENT");
                TranslationTable.Add("en-US#" + "CommentEntryPlaceholder", "Comment (optional)");
                TranslationTable.Add("en-US#" + "RatingLabel", "HOW DO YOU RATE THE APP?");
                TranslationTable.Add("en-US#" + "SendFeedbackButton", "SEND FEEDBACK");
                TranslationTable.Add("en-US#" + "FeedbackInfoTextLine1", "Our Digital Broker App is");
                TranslationTable.Add("en-US#" + "FeedbackInfoTextLine2", "brand new - Help us");
                TranslationTable.Add("en-US#" + "FeedbackInfoTextLine3", "letting us know via the");
                TranslationTable.Add("en-US#" + "FeedbackInfoTextLine4", "feedback function, what");
                TranslationTable.Add("en-US#" + "FeedbackInfoTextLine5", "you like and what");
                TranslationTable.Add("en-US#" + "FeedbackInfoTextLine6", "can be improved!");
                TranslationTable.Add("en-US#" + "FeedbackInfoTextLine7", "");
                TranslationTable.Add("en-US#" + "LoadingTextFeedback", "Sending your feedback");
                TranslationTable.Add("en-US#" + "MsgAlertErrorFeedback", "Your Feedback was sent successfully");
                TranslationTable.Add("en-US#" + "MsgAlertErrorFeedbackError", "Your feedback could not be sent! Please try again");

                // Contact Data page
                TranslationTable.Add("en-US#" + "ContactDataPageTitle", "CONTACT DATA");
                TranslationTable.Add("en-US#" + "ContactDataLabel", "Your contact data");
                TranslationTable.Add("en-US#" + "FirstNameLabel", "FIRSTNAME");
                TranslationTable.Add("en-US#" + "ClientNumberLabel", "CLIENT NUMBER");
                TranslationTable.Add("en-US#" + "DateOfBirthLabel", "DATE OF BIRTH");
                TranslationTable.Add("en-US#" + "MobileNumberLabel", "TELEFON MOBILE");
                TranslationTable.Add("en-US#" + "LastNameLabel", "LASTNAME");
                TranslationTable.Add("en-US#" + "AddressLabel", "STREET / STREET NUMBER");
                TranslationTable.Add("en-US#" + "PostalCodeLabel", "POSTAL CODE");
                TranslationTable.Add("en-US#" + "CityLabel", "CITY");
                TranslationTable.Add("en-US#" + "PrivateEMailLabel", "PRIVATE E-MAIL");
                TranslationTable.Add("en-US#" + "PrivateTelNrLabel", "PRIVATE TELEPHONE NUMBER");
                TranslationTable.Add("en-US#" + "AlertTitle_ErrorReadingUserData", "Error reading user data");
                TranslationTable.Add("en-US#" + "AlertText_ErrorReadingUserData", "User data could not be loaded");
                TranslationTable.Add("en-US#" + "PreferredContactType", "Preferred type of contact");
                TranslationTable.Add("en-US#" + "TypeOfPreferredContact_Phone", "Phone");
                TranslationTable.Add("en-US#" + "TypeOfPreferredContact_EMail", "EMail");
                TranslationTable.Add("en-US#" + "TypeOfPreferredContact_Postal", "Postal");
                TranslationTable.Add("en-US#" + "TypeOfPreferredContact_No", "Not selected");
                TranslationTable.Add("en-US#" + "PickerMethodOfContactTitle", "Preferred type of contact");
                TranslationTable.Add("en-US#" + "SaveAndUploadContactData", "Saving Contact Data");
                TranslationTable.Add("en-US#" + "NoContactDataInfoText1", "Your Contact Data are currently in approval");
                TranslationTable.Add("en-US#" + "MsgAlertContactDataUpload", "Contact Data transmit");
                TranslationTable.Add("en-US#" + "MsgAlertContactDataUploadSuccess", "Your Contact Data were transmitted to Aon. Please note that it could take a while to update the backend system.");
                TranslationTable.Add("en-US#" + "MsgAlertContactDataUploadError", "Your Contact Data could not been transmitted. Please try again later to transmit your data again!");
                TranslationTable.Add("en-US#" + "SalutationTitle", "Salutation");
                TranslationTable.Add("en-US#" + "SalutationMr", "Mr");
                TranslationTable.Add("en-US#" + "SalutationMrs", "Mrs");
                TranslationTable.Add("en-US#" + "CountryLabel", "Country");
                TranslationTable.Add("en-US#" + "HintBirthday18Years", "Minimum age 18 years");

                // Settings page
                TranslationTable.Add("en-US#" + "SettingsPageTitle", "SETTINGS");
                TranslationTable.Add("en-US#" + "LanguageLabel", "LANGUAGE");
                TranslationTable.Add("en-US#" + "LanguageGermanLabel", "Deutsch");
                TranslationTable.Add("en-US#" + "LanguageEnglishLabel", "English");
                TranslationTable.Add("en-US#" + "SyncExternalPoliciesLabel", "Synchronize Non-Aon policies without WLAN");
                TranslationTable.Add("en-US#" + "DeleteAccountButton", "DELETE ACCOUNT");
                TranslationTable.Add("en-US#" + "LoadingTextSwitchingLanguageToGerman", "Switching language to german");
                TranslationTable.Add("en-US#" + "LoadingTextSwitchingLanguageToEnglish", "Switching language to english");
                TranslationTable.Add("en-US#" + "OfflinePINLabel", "OFFLINE PIN LOGIN");
                TranslationTable.Add("en-US#" + "MsgDeletedAccount", "Your Account will be deleted shortly");
                TranslationTable.Add("en-US#" + "UseTouchIDLabel", "Use TouchID for Login");

                // Policies page             
                TranslationTable.Add("en-US#" + "PoliciesPageTitle", "POLICIES");
                TranslationTable.Add("en-US#" + "NoPoliciesInfoText1", "There is currently no policy associated with");
                TranslationTable.Add("en-US#" + "NoPoliciesInfoText2", "this account. Please note that it can take");
                TranslationTable.Add("en-US#" + "NoPoliciesInfoText3", "some days after registration and for new contracts");
                TranslationTable.Add("en-US#" + "NoPoliciesInfoText4", "to synchronize with the app. You can help us speed");
                TranslationTable.Add("en-US#" + "NoPoliciesInfoText5", "up this process by always providing us with your");
                TranslationTable.Add("en-US#" + "NoPoliciesInfoText6", "current email address.");
                TranslationTable.Add("en-US#" + "NoPoliciesInfoText7", "");
                TranslationTable.Add("en-US#" + "NoPoliciesInfoText8", "No Policies assigned.");
                TranslationTable.Add("en-US#" + "NoPoliciesInfoText9", "Are your contracts incomplete or flawed,");
                TranslationTable.Add("en-US#" + "NoPoliciesInfoText10", "please click here.");
                TranslationTable.Add("en-US#" + "CheckPoliciesButton", "Check");
                TranslationTable.Add("en-US#" + "MsgAlertOffline", "Offline Status");
                TranslationTable.Add("en-US#" + "MsgAlertOfflineError", "You are currently not online! So you have no access to the requested data. Please try again when online.");

                // Documents page
                TranslationTable.Add("en-US#" + "DocumentsPageTitle", "DOCUMENTS");
                TranslationTable.Add("en-US#" + "NonAonPolicies", "Non-Aon Policies");
                TranslationTable.Add("en-US#" + "NoNonAonPoliciesInfoText", "You haven't created any Non-Aon Policy yet.");
                TranslationTable.Add("en-US#" + "NewNonAonPolicyButton", "New Non-Aon Policy");
                TranslationTable.Add("en-US#" + "DeleteNonAonPoliciesContextMenu", "Delete");
                TranslationTable.Add("en-US#" + "MsgTitelDeletePolicy", "Delete Non-Aon Policy");
                TranslationTable.Add("en-US#" + "MsgDeletePolicyText", "Do you want to delete this Non-Aon Policy ?");


                // New Non-Aon policy
                TranslationTable.Add("en-US#" + "NewNonAonPolicy", "NEW NON-AON POLICY");
                TranslationTable.Add("en-US#" + "CreateNewNonAonPolicyButton", "CREATE WITH DETAILS");
                TranslationTable.Add("en-US#" + "CreateNewNonAonPolicyWithoutDetailsButton", "CREATE WITHOUT DETAILS");
                TranslationTable.Add("en-US#" + "CategoryLabel", "Category");
                TranslationTable.Add("en-US#" + "LoadingTextLoadingPolicies", "Reading Policies");
                TranslationTable.Add("en-US#" + "LoadingTextLoadingNonAonPolicies", "Reading Non-Aon Policies");
                TranslationTable.Add("en-US#" + "LoadingTextCreatingNonAonPolicy", "Creating Policy");
                TranslationTable.Add("en-US#" + "LoadingTextSavingNonAonPolicy", "Saving Policy");
                TranslationTable.Add("en-US#" + "MsgAlertResult", "Result");
                TranslationTable.Add("en-US#" + "MsgAlertNonAonPolicyCreated", "The Policy was successfully created on your device! Please upload the policy incl. the fotos if required");
                TranslationTable.Add("en-US#" + "MsgAlertNonAonPolicySaved", "The Policy was successfully saved on your device!");
                TranslationTable.Add("en-US#" + "MsgAlertSystemError", "An system error occurred reading the policies");
                TranslationTable.Add("en-US#" + "MsgAlertSystemErrorNonAon", "An system error occurred reading the Non-Aon policies");
                TranslationTable.Add("en-US#" + "MsgAlertSystemErrorNonAonCreate", "An system error occurred creating the Non-Aon policy");
                TranslationTable.Add("en-US#" + "MsgAlertSystemErrorNonAonSave", "An system error occurred saving the Non-Aon policy");
                TranslationTable.Add("en-US#" + "MsgAlertNoCameraTitle", "Camera");
                TranslationTable.Add("en-US#" + "MsgAlertNoCamera", "No camera available");
                TranslationTable.Add("en-US#" + "PickerPolicyType", "Select Policy Type");
                TranslationTable.Add("en-US#" + "PolicyTypeLabel", "Policy Type:");
                TranslationTable.Add("en-US#" + "PickerMethodOfPaymentTitle", "select");
                TranslationTable.Add("en-US#" + "PolicyCommentLabel", "Your comment");
                TranslationTable.Add("en-US#" + "PolicySubjectLabel", "Subject");
                TranslationTable.Add("en-US#" + "LoadingTextUploadingNonAonPolicyImages", "Uploading Policy data and fotos");
                TranslationTable.Add("en-US#" + "MsgAlertFotoUpload", "Upload Status");
                TranslationTable.Add("en-US#" + "MsgAlertFotoUploadError", "Some policy data and fotos were NOT uploaded! Please try again");
                TranslationTable.Add("en-US#" + "MsgAlertFotoUploadSuccess", "Your contract data has been sent to Aon. You will shortly receive further information by e-mail.");
                TranslationTable.Add("en-US#" + "MsgTitelUpload", "Legal Notice");
                TranslationTable.Add("en-US#" + "MsgUploadLegalText", "By submitting the data and / or contracts and / or photos you enter, Aon assumes no liability for the completeness and correctness of the transmitted data. The mere transmission of your contract data does not constitute an obligation for Aon to carry out any business activities.");
                TranslationTable.Add("en-US#" + "MsgUploadLegalText2", "If you are interested in a review of the transmitted contract and would like a comparison offer, please confirm with Accept. Please note that this requires a valid brokerage contract between you and Aon. If this does not exist or the brokerage contract has to be extended, you will receive the necessary documents with separate email and Aon will not be active before the official commissioning.");
                TranslationTable.Add("en-US#" + "MsgUploadLegalTextCancel", "Your contract data has not been transmitted to Aon. The data you entered was stored locally on your device.");
                TranslationTable.Add("en-US#" + "LoadingTextProcessingFoto", "Processing Foto");

                TranslationTable.Add("en-US#" + "PickerNonAonPolicy_Motor", "MOTOR");
                TranslationTable.Add("en-US#" + "PickerNonAonPolicy_ResidentialBuilding", "RESIDENTIAL BUILDING");
                TranslationTable.Add("en-US#" + "PickerNonAonPolicy_Liability", "LIABILITY");
                TranslationTable.Add("en-US#" + "PickerNonAonPolicy_Household", "HOUSEHOLD");
                TranslationTable.Add("en-US#" + "PickerNonAonPolicy_Accident", "ACCIDENT");
                TranslationTable.Add("en-US#" + "PickerNonAonPolicy_PrivateHealth", "PRIVATE HEALTH");
                TranslationTable.Add("en-US#" + "PickerNonAonPolicy_LegalCosts", "LEGAL COSTS");
                TranslationTable.Add("en-US#" + "PickerNonAonPolicy_LifeInsurance", "LIFE INSURANCE");
                TranslationTable.Add("en-US#" + "PickerNonAonPolicy_Generic", "OTHER");
                TranslationTable.Add("en-US#" + "SaveLocalButton", "SAVE POLICY LOCAL");
                TranslationTable.Add("de-DE#" + "DeleteButton", "DELETE POLICY");
                TranslationTable.Add("en-US#" + "MsgCallAnswerOk", "Ok");
                TranslationTable.Add("en-US#" + "MsgCallAnswerAccept", "Accept");
                TranslationTable.Add("en-US#" + "MsgCallAnswerNotAccept", "NOT accepting");

                // Callback page
                TranslationTable.Add("en-US#" + "CallbackPageTitle", "CALLBACK");
                TranslationTable.Add("en-US#" + "CallbackCommentPlaceHolder", "Your comment (optional)");
                TranslationTable.Add("en-US#" + "CallbackTelNrPlaceHolder", "Your phone number");
                TranslationTable.Add("en-US#" + "CallbackButton", "CREATE CALLBACK");
                TranslationTable.Add("en-US#" + "CallbackPage_Today", "Today");
                TranslationTable.Add("en-US#" + "CallbackPage_Between", "between");
                TranslationTable.Add("en-US#" + "CallbackPage_And", "and");
                TranslationTable.Add("en-US#" + "CallbackPage_Clock", "o'clock");
                TranslationTable.Add("en-US#" + "CallbackPage_Day", "Day");
                TranslationTable.Add("en-US#" + "MsgAlertSystemErrorSendingCallback", "An system error occurred creating the callback");
                TranslationTable.Add("en-US#" + "MsgAlertSendingCallback", "The callback was successfully created!");
                TranslationTable.Add("en-US#" + "LoadingTextSendingCallback", "Creating callback");

                // Policies detail page
                TranslationTable.Add("en-US#" + "PoliciesDetailsPageTitle", "POLICY DETAILS");
                TranslationTable.Add("en-US#" + "PolicyContractLabel", "CONTRACT NUMBER *");
                TranslationTable.Add("en-US#" + "PolicyInsurerLabel", "INSURER *");
                TranslationTable.Add("en-US#" + "PolicyAnnualBonusLabel", "ANNUAL PREMIUM *");
                TranslationTable.Add("en-US#" + "PolicyPeriodLabel", "PERIOD");
                TranslationTable.Add("en-US#" + "PolicyMethodOfPaymentLabel", "METHOD OF PAYMENT");
                TranslationTable.Add("en-US#" + "PolicyDueDateLabel", "DUE DATE");
                TranslationTable.Add("en-US#" + "PolicyDetail_Payment_Yearly", "yearly");
                TranslationTable.Add("en-US#" + "PolicyDetail_Payment_HalfYearly", "half-yearly");
                TranslationTable.Add("en-US#" + "PolicyDetail_Payment_Quarter", "quarterly");
                TranslationTable.Add("en-US#" + "PolicyDetail_Payment_Monthly", "monthly");
                TranslationTable.Add("en-US#" + "PolicyDetail_CoverageType_FullyComprehensive", "Fully comprehensive");
                TranslationTable.Add("en-US#" + "PolicyDetail_CoverageType_DamageWaiver", "Damage waiver");
                TranslationTable.Add("en-US#" + "UploadImagesButton", "TRANSFER POLICY TO AON");
                TranslationTable.Add("en-US#" + "FotoListHeaderLabel", "FOTOS");

                TranslationTable.Add("en-US#" + "PolicyType_Motor", "MOTOR");
                TranslationTable.Add("en-US#" + "PolicyType_ResidentialBuilding", "RESIDENTIAL BUILDING");
                TranslationTable.Add("en-US#" + "PolicyType_Liability", "LIABILITY");
                TranslationTable.Add("en-US#" + "PolicyType_Household", "HOUSEHOLD");
                TranslationTable.Add("en-US#" + "PolicyType_Casuality", "ACCIDENT");
                TranslationTable.Add("en-US#" + "PolicyType_PrivateHealth", "PRIVATE HEALTH");
                TranslationTable.Add("en-US#" + "PolicyType_LegalCosts", "LEGAL COSTS");
                TranslationTable.Add("en-US#" + "PolicyType_LifeInsurance", "LIFE INSURANCE");
                TranslationTable.Add("en-US#" + "PolicyType_Generic", "OTHER");

                // Extra Fields for Vehicle Policy
                TranslationTable.Add("en-US#" + "PolicyLicensePlateLabel", "LICENSE PLATE");
                TranslationTable.Add("en-US#" + "PolicyBrandModelLabel", "BRAND / MODEL");
                TranslationTable.Add("en-US#" + "PolicyCoverageTypeLabel", "COVERAGE TYPE");
                TranslationTable.Add("en-US#" + "PolicyHarmFreedomClassLabel", "HARM FREEDOM CLASS");

                // Extra Fields for ResidentialBuilding Policy
                TranslationTable.Add("en-US#" + "PolicyCoverageAmountLabel", "INSURED AMOUNT");
                TranslationTable.Add("en-US#" + "PolicyInsuredRiskLabel", "INSURED RISK");
                TranslationTable.Add("en-US#" + "PolicyValueLabel", "VALUE");
                TranslationTable.Add("en-US#" + "PolicySizeInSMLabel", "SIZE IN m²");
                TranslationTable.Add("en-US#" + "PolicyPerilsLabel", "FIRE/TAP WATER/STORM/HAIL");
                TranslationTable.Add("en-US#" + "PolicyNaturalHazardsLabel", "NATURAL HAZARDS");

                // Extra Fields for Liability Policy
                TranslationTable.Add("en-US#" + "PolicyFlatOrCombinationLabel", "FlatOrCombination");
                TranslationTable.Add("en-US#" + "PolicyDamagaToFinanceLabel", "DAMAGE TO FINANCE");
                TranslationTable.Add("en-US#" + "PolicyDamagaToPersonsLabel", "DAMAGE TO PERSONS");
                TranslationTable.Add("en-US#" + "PolicyDamagaToPropertyLabel", "DAMAGE TO PROPERTY");

                // Extra Fields for HouseHold Policy
                TranslationTable.Add("en-US#" + "PolicyLivingSpaceLabel", "LIVING SPACE");

                // Extra Fields for Casuality Policy
                TranslationTable.Add("en-US#" + "PolicyDisabilityInsuredAmountLabel", "DISABILITY SUM INSURED");
                TranslationTable.Add("en-US#" + "PolicyProgressionLabel", "PROGRESSION");
                TranslationTable.Add("en-US#" + "PolicyPayableAtDeathLabel", "PAYABLE AT DEATH");

                // Non-Aon Policy Vehicle
                TranslationTable.Add("en-US#" + "NonAonPolicyVehiclePageTitel", "Non-Aon Motor Policy");
                TranslationTable.Add("en-US#" + "ValidFromLabel", "VALID FROM");
                TranslationTable.Add("en-US#" + "ValidToLabel", "VALID TO");
                TranslationTable.Add("en-US#" + "CreateButton", "CREATE");
                TranslationTable.Add("en-US#" + "SaveButton", "SAVE");
                TranslationTable.Add("en-US#" + "PolicyFotoButton", "PHOTOGRAPH POLICY");

                // Non-Aon Policy Residentaial Building 
                TranslationTable.Add("en-US#" + "NonAonPolicyResidentialBuildingPageTitel", "Non-Aon Residential Building Police");

                // Non-Aon Policy Liability 
                TranslationTable.Add("en-US#" + "NonAonPolicyLiabilityPageTitel", "Non-Aon Liability Policy");

                // Non-Aon Policy Household 
                TranslationTable.Add("en-US#" + "NonAonPolicyHouseholdPageTitel", "Non-Aon Household Policy");

                // Non-Aon Policy Casuality 
                TranslationTable.Add("en-US#" + "NonAonPolicyCasualityPageTitel", "Non-Aon Accident Policy");

                // Non-Aon Policy PrivateHealth 
                TranslationTable.Add("en-US#" + "NonAonPolicyPrivateHealthPageTitel", "Non-Aon Private Health Policy");

                // Non-Aon Policy LegalCosts 
                TranslationTable.Add("en-US#" + "NonAonPolicyLegalCostsPageTitel", "Non-Aon Legal Costs Policy");

                // Non-Aon Policy LifeInsurance 
                TranslationTable.Add("en-US#" + "NonAonPolicyLifeInsurancePageTitel", "Non-Aon Life Insurance Policy");

                // Non-Aon Policy Generic 
                TranslationTable.Add("en-US#" + "NonAonPolicyGenricPageTitel", "Non-Aon Other Policy");


                // Notify change Page
                TranslationTable.Add("en-US#" + "NotifyChangePageTitel", "NOTIFY CHANGE");
                TranslationTable.Add("en-US#" + "ReasonLabel", "REASON");
                TranslationTable.Add("en-US#" + "NotifyButton", "SEND NOTIFICATION");
                TranslationTable.Add("en-US#" + "NotifyReasonType", "Select reason");
                TranslationTable.Add("en-US#" + "PickerNotifyReason_WrongLegacyData", "Wrong contact data");
                TranslationTable.Add("en-US#" + "PickerNotifyReason_WrongPolicyData", "Error in policy");
                TranslationTable.Add("en-US#" + "PickerNotifyReason_MissingPolicy", "Missing policy");
                TranslationTable.Add("en-US#" + "PickerNotifyReason_OtherReason", "Other");
                TranslationTable.Add("en-US#" + "WrongPolicyPickerTitel", "Select wrong policy");
                TranslationTable.Add("en-US#" + "LoadingTextSendingNotification", "Sending change notification");
                TranslationTable.Add("en-US#" + "MsgAlertErrorSendingNotification", "An error occurred sending the change notification");
                TranslationTable.Add("en-US#" + "NotifyCommentLabel", "YOUR COMMENT");
                TranslationTable.Add("en-US#" + "MsgAlertSuccessSendingNotification", "The change notification was sent successfully");

                // New external policy image big page
                TranslationTable.Add("en-US#" + "DeleteImageButton", "DELETE FOTO");
                TranslationTable.Add("en-US#" + "NoFotoButton", "PROCEED WITHOUT FOTO");
                TranslationTable.Add("en-US#" + "WithFotoButton", "PROCEED WITH THIS FOTOS");
                TranslationTable.Add("en-US#" + "MakeNewNonAonPolicyFotosLabel", "Take fotos of your police if required and possible");

                // Connectivity Status (Toolbar)
                TranslationTable.Add("en-US#" + "MsgAlertConnectivityTitle", "Connectivity Status");
                TranslationTable.Add("en-US#" + "MsgAlertConnectivityOffline", "Your are currently Offline");
                TranslationTable.Add("en-US#" + "MsgAlertConnectivityOnline", "Your are currently Online");

            }
        }

        /// <summary>
        /// Checks the translate table in db.
        /// </summary>
        /// <returns><c>true</c>, if translate table in db was checked, <c>false</c> otherwise.</returns>
        private static bool CheckTranslateTableInDB()
        {
            bool result = false;

            IDatabase databaseService = FreshIOC.Container.Resolve<IDatabase>();
            string value = String.Empty;

            if (App.Language == App.LanguageType.German)
            {
                value = databaseService.ReadDBValue("de-DE#" + "LogInButton");
            }

            if (App.Language == App.LanguageType.English)
            {
                value = databaseService.ReadDBValue("en-US#" + "LogInButton");
            }

            result = value != String.Empty;

            return result;
        }

        /// <summary>
        /// Writes the translation table to db.
        /// </summary>
        private static void WriteTranslationTableToDB()
        {
            IDatabase databaseService = FreshIOC.Container.Resolve<IDatabase>();

            foreach (var key in TranslationTable.Keys)
            {
                databaseService.UpdateDBValue(key, TranslationTable[key]);
            }
        }

        /// <summary>
        /// Gets the translation changes from backend.
        /// </summary>
        private static void GetTranslationChangesFromBackend()
        {
            // Here get backend changes
            Dictionary<string, string> translationTableChanges = new Dictionary<string, string>();
            IDatabase databaseService = FreshIOC.Container.Resolve<IDatabase>();

            translationTableChanges.Add("de-DE#" + "WelcomeLabel", "Willkommen");

            // Set changes in memory dictionary and local DB
            foreach (var key in translationTableChanges.Keys)
            {
                if (TranslationTable.ContainsKey(key) == true)
                {
                    TranslationTable[key] = translationTableChanges[key];
                    databaseService.UpdateDBValue(key, translationTableChanges[key]);
                }
            }

        }

        /// <summary>
        /// Reads the translation table from db.
        /// </summary>
        private static void ReadTranslationTableFromDB()
        {
            string culture = "en-US"; // Default
            culture = App.Language == App.LanguageType.German ? "de-DE" : culture;
            IDatabase databaseService = FreshIOC.Container.Resolve<IDatabase>();

            Dictionary<string, string> translationValues = databaseService.ReadTranslationValues(culture);

            TranslationTable.Clear();
            foreach (var translationValueKey in translationValues.Keys)
            {
                TranslationTable.Add(translationValueKey, translationValues[translationValueKey]);
            }
        } 

        /// <summary>
        /// Sets the app language on device UI Language OR use saved DB language value
        /// </summary>
        private static void SetAppLanguageOnDeviceUILanguageORLocalDBLanguageValue()
        {
            IDatabase databaseService = FreshIOC.Container.Resolve<IDatabase>();

            string readAppLanguage = databaseService.ReadDBValue("AppLanguage");
            if (readAppLanguage == "English")
            {
                App.Language = App.LanguageType.English;
            }

            if (readAppLanguage == "German")
            {
                App.Language = App.LanguageType.German;
            }

            App.Language = App.LanguageType.NotSet;
            if (App.Language == App.LanguageType.NotSet)
            {
                // Set device UI language as default
                string locale = L10n.Locale();

                if ((locale.ToUpper().StartsWith("DE-", StringComparison.CurrentCulture) == true))
                {
                    App.Language = App.LanguageType.German;
                    databaseService.UpdateDBValue("AppLanguage", "German");
                }
                else
                {
                    App.Language = App.LanguageType.English;
                    databaseService.UpdateDBValue("AppLanguage", "English");
                }
            }
        }
    }

}

