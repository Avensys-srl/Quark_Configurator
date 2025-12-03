# RD Programmer

Windows Forms utility (VB.NET, .NET Framework 4.8) to configure Quark units over a serial link, read/write customer data, monitor live data, and run automated acceptance tests that produce Markdown and PDF reports.

## Main features
- Serial console with explicit commands (2/6/7/A/B/C) to read unit data, customer data, write data, toggle live data, and set date/time.
- Robust live-data parser: status bitfield to flags, Belimo inputs/state mapping, alarms list, heater handling based on accessories, RPM/voltages/temperatures/humidity.
- Automated unit test runner (Speed1 100/60/30) with waits, validations, restore of original speeds, Markdown log generation, and pass/fail beeps.
- Temperature/humidity/Belimo current/RPM checks with moving averages (10 samples), re-tries, and clear pass/fail messages in both on-screen log and report.
- Log management: unique naming with numeric suffixes, auto-creation of `test` and `test/failed`, preview panel with mm:ss timestamps, double-click to open reports, and file-exists prompts.
- Export to PDF via wkhtmltopdf using an in-app HTML template (lighter fonts, white background, card panels, footer with serial on the left and page numbers on the right).
- Recovery safeguards: auto reconnect after menu option C if the prompt stalls on "Writing standard HW accessories...", live-data toggle safety (send B twice to disable), and non-blocking stop/cancel.
- Audio feedback: distinct beep patterns for PASS, FAIL, and CANCEL to draw operator attention.

## UI at a glance
- **Configurator**: connect/disconnect to a COM port, read/write unit and customer data, toggle live data safely, and keep the COM list intact during reconnects.
- **Live data**: shows parsed fields (temps, humidity, RPM, voltages, status flags, Belimo state/current, alarms). Status text mirrors the FTP/status bar for clarity.
- **Unit test**: start/stop buttons, read-only log preview cleared at each run with mm:ss prefix per line, test-folder quick access, report list (double-click to open), export-to-PDF icon/button, and status label for current file name (wrapped text).

## Automated unit test flow (Speed1 only)
1) Read unit data (2) and customer data (6).
2) Capture initial live data (B) after waiting up to 60 s; always send B again to close streaming.
3) Validate temps/humidity/Belimo current/RPM. Temp failures trigger an extra 15 s sampling window before failing.
4) Apply variations for Speed1: 100%, then 60%, then 30% (Speed2/3 stay unchanged). After sending 7, wait for completion.
5) Re-read config with 6 to confirm Speed1 write.
6) Enable live data for 30-60 s, sample, then disable live data (send B again).
7) RPM change must follow the target direction and be >= 300 compared with the previous step; log both current and previous targets.
8) On any failure: stop, append reason to on-screen log and Markdown, move log to `test/failed`, suffix `_failed`, and beep FAIL.
9) On success: restore original speeds (S1/S2/S3), append footer with end time/duration/result PASSED, refresh list, and beep PASS.

## Validation rules
- **Temperatures**: use the moving average of the last 10 readings; each pair |F-R| and |S-E| <= 3 degC, pair averages within 5 degC. One retry after 15 s if out of range.
- **Humidity**: |L-R| <= 8%.
- **Belimo current**: if `NO_FKI = 0`, current must be > 200 mA; otherwise skipped.
- **RPM trend**: must increase when target rises and decrease when it drops, with absolute delta >= 300 vs previous live sample.
- **Heater**: shown as value only if EHD accessory is present; otherwise `N/A` when 0.

## Logging and reports
- Markdown logs saved under `bin/Release/test`; failures go to `bin/Release/test/failed` with `_failed` suffix. Duplicate names get `_001`, `_002`, etc after a user prompt.
- Each log includes start/end timestamps, duration, step-by-step serial exchanges, live data with status flags and alarms, environmental checks, RPM checks, Belimo state, and final PASS/FAIL.
- On-screen log mirrors key steps with mm:ss prefixes and is cleared whenever a new test starts.
- Export to PDF: generates a temporary HTML (white background, light gray cards for serial blocks, smaller fonts) and calls `wkhtmltopdf --dpi 300 --image-dpi 300 --image-quality 90 --print-media-type --disable-smart-shrinking --enable-local-file-access --footer-left "Serial: ..." --footer-right "[page]/[topage]"`. wkhtmltopdf must be reachable on PATH.

## Serial safety and recovery
- Live data is a toggle: B to start, B to stop; the app enforces the second B before other commands.
- After sending menu option C, if the console stays on "Writing standard HW accessories to EEPROM...", the app auto-disconnects and reconnects to the same COM, without losing the port list.
- Stop/Cancel buttons interrupt the test and still restore the original speed.

## Requirements
- Windows with .NET Framework 4.8.
- Visual Studio 2019+ (Windows Forms, VB.NET) to build.
- wkhtmltopdf installed and on PATH for PDF export (pandoc optional if you prefer its HTML generation).
- USB/serial driver for the target device; access to the COM port.

## Build and run
1. Open `CLRD_programmer.sln` in Visual Studio.
2. Restore NuGet packages (`System.CodeDom`, `System.Management`).
3. Build `RD_programmer` (Release for production); output lives under `RD_programmer/bin/Release/`.
4. Run the app, pick the correct COM port, and click **Connect**.

## Typical workflows
- **Manual configuration**: Connect -> Read unit (2) -> Read customer data (6) -> adjust values -> Write customer data (7) -> verify with (6) -> toggle live data (B/B) to observe results.
- **Automated test**: Connect -> open Unit Test tab -> ensure serial number is set -> click **Start test** -> monitor the preview -> on completion, open the generated Markdown or export to PDF. Logs auto-move to `failed` on errors.
- **Export PDF**: Select a report in the list -> click the PDF icon/button -> the file is placed next to the Markdown with `.pdf` extension.

## Troubleshooting
- **Menu stuck after option C**: the app auto-reconnects; if still stuck, manually Disconnect/Connect and resend the command.
- **Live data keeps streaming**: ensure B was sent twice; the app enforces the toggle before new commands.
- **wkhtmltopdf errors**: confirm it is installed and available on PATH; the app shows exit code/output on failure.
- **Beep patterns**: PASS, FAIL, and CANCEL have different tones to alert the operator when away from the screen.

## License
Add your license terms here (currently unspecified).
