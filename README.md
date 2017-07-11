# F4-SMS
F4-SMS is a standalone simulation of the Stores Management Subsystem page within the Multi Function Display Suite for the Lockheed Martin Fighting Falcon F-16 strike fighter. This interactive tool is presently in development, but will soon allow simple demonstration of the functionality of the Stores Management Subsystem and its various sub pages and modes.

## SMS
The SMS links multiplexed data communication between displays, weapons delivery avionics, and store suspension equipment. Weapons delivery is facilitated by the MFDS, which provides displays of store status and weapons delivery modes, allowing delivery options to be preprogrammed in flight via the ICP. SMS functions are selected via the ICP, MFDS, and hands-on controls. 

The SMS mode configuration may be preprogrammed. When a mode is entered, the last previous configuration is recalled (the only exception occurring after an intervening power interruption). Dogfight (DGFT) and missile override (MSL OVRD) master modes are preprogrammed and selected via the DOGFIGHT/missile override switch on the throttle. These modes override all other MFD selected modes. After the DGFT or MSL OVRD mode is deselected, the MFD selected mode is restored; thus, three attack modes are available hands-on.

## SMS Format
The SMS format provides for stores inventory and loading, weapons delivery mode selection, and weapons release parameter selection. These controls and data are generally a function of the SMS mode as discussed in subsequent paragraphs.

The following SMS page displays provide controls and data for these functions:
+ OFF (SMS off) – When the MMC and ST STA power switch is OFF or if the MFDS can not communicate with the SMS.
+ STBY (SMS standby) – STBY mode allows loading and verification of stores inventory.
+ INV (inventory) – Automatically displayed when standby mode is accessed and selectable via all SMS modes except EJ, S-J, and BIT.
+ S-J (selective jettison) – Selected via OSB adjacent to S-J mnemonic on all SMS pages except BIT, data entry, and E-J.
+ E-J (emergency jettison) – Selected via EMER STORES JETTISON button on landing gear panel; overrides all other master modes except AIM-120 launch in progress.
+ AAM (air-to-air missile) – Selected via AAM/GUN rotary OSB’s when A-A master mode is selected.
+ MSL (missile override) – Selected hands-on via DOGFIGHT/missile override switch; overrides all master modes except E-J.
+ DGFT (dogfight) – Selected hands-on via DOGFIGHT/missile override switch; overrides all master modes except E-J and BIT. Provides EEGS/LCOS rotary.
+ GUN (gunnery) – Selected via AAM/GUN rotary when A-A is selected or A-G/GUN rotary when A-G is selected and provides EEGS rotary in A-A or STRAFE gunsight in A-G.
+ A-G (air-to-ground) – Selected via A-G/GUN rotary when A-G master mode is selected.
+ BIT (built-in test) – Selected via MFD TEST page.

## Copyright and Licensing
F4-SMS is copyright © 2017 Bill 'Blu3wolf' Teale. 

This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version.

This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU General Public License for more details.

You should have received a copy of the GNU General Public License along with this program.  If not, see <http://www.gnu.org/licenses/>.
