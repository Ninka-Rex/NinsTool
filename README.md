<div align="center">
<img src="https://public-files.gumroad.com/7bldn5ro30ey28fnxlzl9brcf534" height="256">
<div align="left">
  
# Nin's Tool for Oculus Link 🔗✨

Nin's Tool for Oculus Link is a simple and easy-to-use program that lets you tweak your Oculus Link settings and keep them that way forever! No more fiddling with debug tool every session. Nin's Tool will save your settings and automatically apply them each session. (if you enable auto launch) :rocket:
You can try it for free or buy Nin's Tool [here!](https://ninka.gumroad.com/l/NinsTool)

# ⚠️⚠️⚠️ Code warning!!! ⚠️⚠️⚠️

This code is awful. It is the result of countless hours of trial and error, hacking and patching, copying and pasting, and praying and hoping. It is not elegant, not efficient, not readable, not maintainable, not scalable, not portable, not reusable, not testable, not debuggable, not anything-able. It is a mess of spaghetti code that barely holds together by sheer luck and force of will. It is a miracle that it works at all.

But it works. Somehow, it works. It does what it is supposed to do, most of the time. It has survived the tests of time and users, and it has proven its worth in the real world. It is not pretty, but it is functional. It is not perfect, but it is good enough. It is not a masterpiece, but it is a product. 

I am only publishing the source code due to popular demand, and due to the fact that virtual desktop made NT obsolete by introducting face tracking support.

You have been warned.


## The program has options for:

- Encoding bitrate
- Encode codec
- Asynchronous Spacewarp (🤢)
- Local Dimming (Quest Pro Only)
- Sliced encoding (Fix white bar issue)
- Quickly restarting Oculus services
- Turning Guardian on/off
- Link Sharpening
- Battery Indicator
- Debug Huds
- Screen Brightness
- Proximity Sensor
- One-click install for Oculus Killer and more

Features:

- Intuitive
- Doesn't require administrator privileges
- Retains your settings
- Uses little system resources
- Dark mode 🥵
- Rexouium-coded 🐾
- Connects over WiFi or Wire

## Airlink Users ☝️🤓
Nin's Tool uses android debug bridge (ADB) to control features on quest, however establishing this connection wirelessly can be tricky, but it's not necessary to use Nin's Tool- it's just that ASW, Brightness, and Guardian settings will be disabled. To make sure Nin's Tool can properly connect to your headset, follow these steps:
  - make sure the Oculus desktop app recognizes your quest wirelessly.
  - Enable USB connection dialogue in quest settings > system > developer
  - Plug the quest into your computer using USB, and click "Allow" in the headset
  - Unplug USB
  - Refresh the connection by clicking the battery indicator button in Nin's Tool.
There's nothing I can do to streamline this process, it's just the way ADB works. So, I can only recommend a link cable for using link.

## Installation :floppy_disk:

You can download Nin's Tool for Oculus Link from [Gumroad](https://ninka.gumroad.com/l/NinsTool). The program is compatible with Windows 10 and 11, and Meta Quest 1, 2, Pro, and 3. 

## Support :handshake:

If you have any questions or feedback, please email me at nin@nin.wtf or disc: ninka_

If you can't afford the full version of Nin's Tool, please email me: nin@nin.wtf or disc: ninka_

Remember, Nin's Tool will completely override your Oculus Link settings, so if you need to change something with debug tool, close nins tool and disable auto start.

## License :page_facing_up:

Nin's Tool is paid software. You can buy it [on my gumroad](https://ninka.gumroad.com/l/NinsTool)

## Changelog :memo:

R1.2.3 8/20/23

- Fixed an issue where ASW wasn't being set to the preferred setting upon launching Link
- Fixed an issue where settings weren't being regularly applied while link is running
- Fixed an issue (hopefully) where screen brightness would randomly dim for some reason. It should be reset to the correct brightness every minute now.
- Better handling of the "Unauthorized" wireless connection state (airlink users see below)
- Fixed exception when trying to retrieve the headset's brightness percentage
- Local Dimming settings will be disabled if you aren't using a Quest Pro
- New Icon

R1.2 7/20/23

- New! Added support for Oculus Link's new "Quality" sharpening mode (it looks really good)
- New! Added controller battery indicators
- New! Added an indicator for when your room is too dim
- New! Added screen brightness controls, can brighten/darken way beyond the normal limit.

R1.1.1 7/1/23

- Bug fix

