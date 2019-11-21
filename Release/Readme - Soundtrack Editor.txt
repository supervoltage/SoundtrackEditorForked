-------------------------------------------------------------
 Soundtrack Editor
 Author:    pizzaoverhead
 Version:   4.3
 Released:  2017-03-01
 KSP:       v1.2.2

 Thread:    http://forum.kerbalspaceprogram.com/threads/52896
 Licence:   GNU v2, http://www.gnu.org/licenses/gpl-2.0.html
 Source:    https://github.com/pizzaoverhead/RcsSounds
-------------------------------------------------------------

Description
-----------
Adds a dynamic soundtrack system to KSP. Allows creating playlists of tracks and setting the conditions under which they are played. Some stockalike tracks by Kevin MacLeod are included, as is a replacement for the KSC birdsong ambiance based on a track by freesound.org user dobroide. This plugin also makes use of MPG123 and associated code, licenced under GNU LGPL v2 (included).


Installation
------------
Extract the entire contents of the zip to the root KSP folder, merging the folders with the existing KSP folders.


Usage
-----
Drop any new .wav, .ogg or .mp3 files you want to use into the Music folder, next to KSP.exe.
You can create as many sub folders here as you want to organise the tracks.
Start up KSP and go to the KSC or flight menu. Click on the music speaker icon in the application launcher to open the Soundtrack Editor.


Uninstallation
--------------
Delete the SoundtrackEditor folder from GameData.
Delete the Licenses, Music, Playlists and Sources folders from the root KSP folder (next to KSP.exe).
Delete the file libmpg123-0.dll from the Mono folder inside the KSP_Data and KSP_x64_Data folders.


More Music
----------
This mod includes a selection of tracks by Kevin MacLeod, composer of some of the music used in KSP. He has several thousand tracks, many in the same style as is used in KSP, available for free at incompetech.com.


Credits
-------
This mod makes use of an edited version of the sound "20060824.forest03.wav" and "20060706-night-forest02.wav" by dobroide. The originals are available here:
http://www.freesound.org/people/dobroide/sounds/22384/
https://www.freesound.org/people/dobroide/sounds/20575/

The following included tracks are by Kevin MacLeod, and are available at incompetech.com:
Investigations
Darkest Child
Dragon and Toast
Fairytale Waltz
Martian Cowboy
Mysterio March
Numinous Shine
On the SHore
Peaceful Desolation
The Other Side of the Door


Version history
---------------
4.3 (2017-03-01)
- Added text for the current value of editable selections in the Playlist Editor.
- Fixed Mission control ambience playlist's track.
- Fixed playlists only activating on leaving the scene for the Astronaut Complex, Mission Control and Research & Development scenes.
- Added missing AdminFacility psuedo-scene.
- Removed empty entries from the persistor for preloadTime, playNext, playBefore, PlayAfter and minVelocity/Altitude values.
- Fixed error on seeking to the end of a clip.
- Fixed clicking "Cancel" on the Edit Playlist entries for In Atmosphere, Time Of Day, Scene, Situation and Camera Mode changing their values.
- Fixed the Scene picker "Any" toggle not being able to deselect all entries.
- Positioned Cancel buttons constantly to the right.
- Fixed unexpected behaviour when track length is less than the set preload time.

4.2 (2017-02-28)
- Fixed unloaded tracks not being loaded correctly.
- Added warning message for failing to find a requested audio track.
- Removed unneeded log statements.
- Fixed error on seeking to the end of a file.

4.1 (2017-02-25)
- Support for latest KSP version.
- Fixed load failure for MP3s with no ID3 tags.

4.0 (2016-08-19)
- Advanced soundtrack management engine allows you to specify conditions that different soundtracks should play in, such as underwater, during reentry or at KSC during the night.
- No more editing text files! Full-featured GUI for creating and organising playlists.
- Audio player: See the name of the current track, skip ones you don't like, pause the sound or adjust the volume.
- Audio preview system: Listen to all the music and sound effects included in stock KSP, including hidden and unused sounds.
- Application launcher integration.
- KSC night-time crickets.

3.0 beta
- Completely rewritten playback management, playlists and memory management.
- Dynamic loading of tracks: Only the current track needs to be in memory.
- Environment-aware playlists: Have a specific track play when you go supersonic or splash down.
- Looping and shuffling.
- Track preloading.

2.1a (2014-08-08)
- Added x64 option with alternate folder layout.
- Added support for the KSP Add-on Version Checker.

2.1 (2014-01-20)
- Added the "none" option to disable music for a specific scene, e.g. menuTheme = none
- Fixed directory separators on non-Windows systems.
- Removed debug messages.

2.0 (2014-01-16)
- Added support for MP3 tracks.

1.0 (2014-01-11)
- Initial release.