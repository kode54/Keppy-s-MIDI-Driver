# Keppy's MIDI Driver
A fork of the original [BASSMIDI Driver by Kode54] (https://github.com/kode54/BASSMIDI-Driver), with new functions.

## What's the difference between the original driver and your fork?
I optimized this fork by doing these things:
- Blacklist in the driver, to prevent strange processes from blocking it
- Modifiable audio frequency
- Modifiable samples per frame value
- Note off event and sound effects disabler settings
- Better UI for the configurator

## System requirements
- A CPU that supports CMPXCHG8b, running at 166MHz
- 32MB of RAM (for basic soundfonts)
- Microsoft Visual C++ 2013 & .NET Framework 4.0
- Windows XP SP3 or greater

## Are you trying to overshadow the original project?
Absolutely no, Kode54's driver is better than mine tho. (His code is more cleaner, and way more stable)

You can download it from there here: https://github.com/kode54/BASSMIDI-Driver
