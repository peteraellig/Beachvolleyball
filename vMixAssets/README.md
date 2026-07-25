# vMix Assets Installation

These files are required by Beach Volleyball Scorer and its supplied vMix
graphics package.

## Hard-coded installation path

The application and the included `settings.xml` use the following fixed
Windows directory:

```text
C:\vMix\Beachvolleyball\
```

Install the assets at exactly this location. Using another directory requires
changing the paths in the application settings and may prevent graphics,
flags, logos, or other media from loading.

## What to copy

Copy **everything inside this `vMixAssets` directory** to:

```text
C:\vMix\Beachvolleyball\
```

Do not copy the outer `vMixAssets` directory as an additional folder level.

Correct:

```text
C:\vMix\Beachvolleyball\advertising\
C:\vMix\Beachvolleyball\flags\
C:\vMix\Beachvolleyball\graphical templates\
C:\vMix\Beachvolleyball\stationlogo\
C:\vMix\Beachvolleyball\testbg\
C:\vMix\Beachvolleyball\titles\
C:\vMix\Beachvolleyball\weatherLogos\
C:\vMix\Beachvolleyball\settings.xml
C:\vMix\Beachvolleyball\volley.xml
```

Incorrect:

```text
C:\vMix\Beachvolleyball\vMixAssets\titles\
```

## Installation steps

1. Close Beach Volleyball Scorer before replacing an existing installation.
2. Create `C:\vMix\Beachvolleyball\` if it does not already exist.
3. Copy all folders and files from this directory into that destination.
4. When updating an existing installation, make a backup of your current
   `settings.xml` and `volley.xml` first.
5. Merge or retain your existing XML files if they contain production settings
   or team data that must not be overwritten.
6. Start Beach Volleyball Scorer and open **Settings**.
7. Confirm the vMix host, HTTP/TCP ports, and all configured media paths.
8. Use **Check Missing Files** to verify the installation.
9. Use **Install GTZIP Inputs** to load the configured GT titles into vMix, or
   add the required titles manually.
10. Test every graphic before using the setup in a live production.

## Directory contents

| Path | Purpose |
|---|---|
| `advertising/` | Advertising graphics and GT titles |
| `flags/` | Country flags named by ISO3/FIFA-style country code |
| `graphical templates/` | Editable artwork and graphics source files |
| `stationlogo/` | Station logo and watermark GT titles |
| `testbg/` | Sample backgrounds for testing |
| `titles/` | Scorebug, result, lower-third, event, weather, and transmission GT titles |
| `weatherLogos/` | Weather condition icons |
| `settings.xml` | Sample/default application and vMix graphics configuration |
| `volley.xml` | Sample/default team and player data |

## Important: preserve local data

`settings.xml` and `volley.xml` are writable application data:

- `settings.xml` contains the vMix connection, ports, scoring configuration,
  event information, and paths to graphics.
- `volley.xml` contains team and player records.

Copying the repository versions over an existing installation will replace
local changes. Back up both files before an update.

Windows file paths are case-insensitive, but the directory structure and file
names should otherwise be kept unchanged.
