# RD Programmer

VB.NET Windows Forms tool (.NET Framework 4.8) to configure Quark units via serial, read/write customer data, monitor live data, and run automated acceptance tests that produce Markdown and PDF reports.

## Highlights
- Serial command console (2/6/7/A/B/C) for unit data, customer data, writes, live data toggle, and date/time.
- Live-data parser: status bitfield to flags, Belimo inputs/state mapping, alarms decoding, heater conditional display (EHD accessory), RPM/voltages/temps/humidity, Belimo current.
- Automated unit test (Speed1 sequence 100/60/30) with waits, validations, automatic restore of original values, Markdown + PDF output, and audio beeps for PASS/FAIL/CANCEL.
- Environmental checks with moving averages (temps, humidity), Belimo current >200 mA when NO_FKI=0, RPM delta ≥300 with correct trend, heater shown as N/A when not applicable.
- Log handling: unique filenames with suffixes, auto-create `test` and `test/failed`, preview panel with mm:ss timestamps (cleared at each start), double-click to open, PDF export via wkhtmltopdf with footer (serial/page numbers).
- Safety: live-data toggle enforcement (send B to stop if streaming is detected on connect/after 2/6), auto-reconnect after menu option C, non-blocking cancel, serial recovery when accessories write hangs.
- UI toggles: hide/show Service tab (Ctrl+Alt+S) and Unit Test tab (Ctrl+Alt+T); status label wraps the log file name; test log preview clears on each run.
- KHK visibility driven by external XML (`khk_visibility.xml`) or optional API JSON; no merge—API wins, else XML, else defaults.

## Automated unit test (Speed1 only)
1. Read unit data (2) and customer data (6); cache originals (Speed1/2/3, RH setpoint, imbalance enable, KHK config, smoke contact).
2. Capture initial live data (B) with up to 60 s wait; always toggle B again to close streaming.
3. Validate temps/humidity/Belimo current; retry temps/humidity after 15 s if needed.
4. Force during test: RH=99, imbalance disabled, KHK disabled, smoke disabled; Speed1 variations only (100 → 60 → 30), Speed2/3 unchanged.
5. After each variation: save (7), re-read config (6), confirm Speed1, read live (30–60 s), check temps/humidity/Belimo, check RPM trend (≥300, correct direction). Toggle B off after live read.
6. On failure: log reason, move report to `test/failed` with `_failed` suffix, beep FAIL, stop.
7. On success: restore original Speed1/2/3, RH setpoint, imbalance, KHK, smoke; refresh data; write footer with end time/duration/result; beep PASS.

## Validation rules
- Temperatures: moving average of last 10 live samples; |F-R| ≤ 3 °C, |S-E| ≤ 3 °C, pair averages within 5 °C; extra 15 s retry on failure.
- Humidity: |L-R| ≤ 8%.
- Belimo current: >200 mA if `NO_FKI = 0`; skipped otherwise.
- RPM trend: must follow target direction with absolute delta ≥300 vs previous live sample.
- Heater: value only if EHD present; otherwise `N/A` when 0.

## Logging and reports
- Markdown in `bin/Release/test`; failures go to `bin/Release/test/failed` with `_failed` suffix. Duplicate names get `_001`, `_002`, etc after user prompt.
- Each log: start/end, duration, serial exchanges, live data (flags, alarms, Belimo states), env checks, RPM checks, restoration details, final result.
- On-screen log: mm:ss prefix, cleared at each start; mirrors key steps.
- PDF export: HTML template (white background, light gray cards), wkhtmltopdf with `--dpi 300 --image-dpi 300 --image-quality 90 --print-media-type --disable-smart-shrinking --enable-local-file-access --footer-left "Serial: ..." --footer-right "[page]/[topage]"`.

## Serial safety & recovery
- Live data is a toggle: B on/B off. On connect and after commands 2/6, a monitor watches for live streaming (10s) and sends B to stop if needed.
- After menu option C stalls on “Writing standard HW accessories...”, auto disconnect/reconnect same COM without losing the port list.
- Cancel/stop restores original values; errors also restore and refresh data.

## KHK visibility config
- File: `khk_visibility.xml` (local) or API JSON (if endpoint set). API list wins; otherwise XML; otherwise defaults (9999, 7603<110, 8705, 8910). Example JSON:
```json
{ "serialPatterns": [ { "prefix": "9999" }, { "prefix": "7603", "maxLast3": 110 } ] }
```

## Build & run
1. Open `CLRD_programmer.sln` in Visual Studio (2019+).
2. Restore NuGet packages (`System.CodeDom`, `System.Management`); references include `System.Net.Http`, `System.Web.Extensions` for API parsing.
3. Build `RD_programmer` (Release output under `RD_programmer/bin/Release/`).
4. Run, pick COM port, click **Connect**.

## Typical workflows
- Manual: Connect → 2 → 6 → adjust → 7 → verify (6) → live data (B/B) to observe.
- Automated: Connect → Unit Test tab → set serial → Start test → watch preview → open Markdown or export PDF; failures auto-move to `failed`.
- PDF: select report → click PDF icon/button → generated next to the Markdown.

## Troubleshooting
- Menu stuck after C: auto-reconnect runs; if still stuck, manual disconnect/connect and resend.
- Live data keeps streaming: ensure B was sent twice; connect/2/6 monitoring will also try to stop it.
- wkhtmltopdf errors: ensure it’s installed and on PATH; dialog shows exit code/output.
- Beeps: distinct patterns for PASS/FAIL/CANCEL to alert the operator.

## License
Add your license terms here (currently unspecified).
