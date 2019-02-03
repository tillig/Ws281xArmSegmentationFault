# WS281x ARM Segmentation Fault

I'm using a Raspberry Pi 3B+ with Raspbian trying to control a string of WS2812B lights with [a common library](https://github.com/jgarff/rpi_ws281x) that interfaces via the GPIO pins.

I've found that I inconsistently get a segmentation fault somewhere around the P/Invoke area. This repo is about creating a minimal reproduction that can be used for troubleshooting and illustrating [the issue](https://github.com/dotnet/coreclr/issues/22384).

# Logs

The `logs` folder contains stack traces and logs gathered from the Raspberry Pi during troubleshooting.

- `strace1.txt`, `strace2.txt`: Logs gathered via `sudo strace ./ConsoleDemo $> ~/strace.txt`
- `gdb.txt`: Log from running the program through `gdb`. Error consistently in `WKS::gc_heap::mark_object_simple(unsigned char**) () from /home/pi/consoledemo/libcoreclr.so`

# Notes

Since this uses the GPIO pins, you need to run it with `sudo`.

This was initially found by building on Windows 10 on .NET Core SDK 2.2.103 and then doing a publish to `linux-arm` using a folder-based publish profile in Visual Studio.

I also installed the .NET Core SDK 2.2.103 right on the Raspberry Pi to reproduce it.
- `sudo dotnet run` doesn't actually end up running the program. No console output is seen, no errors, it just builds and then does nothing.
- `dotnet publish -r linux-arm` in the `ConsoleDemo` folder does publish the complete app in `/src/ConsoleDemo/bin/Debug/netcoreapp2.2/linux-arm/publish` but running `sudo ./ConsoleDemo` still yields the segmentation fault. Building/publishing from the RPi itself doesn't seem to make a difference.

Seems there are lots of segmentation fault issues on ARM.

- https://www.google.com/search?q=segmentation+fault+gc_heap+mark_object_simple+libcoreclr
- https://github.com/dotnet/coreclr/issues/18564
- https://github.com/dotnet/coreclr/issues/13500
- https://github.com/dotnet/coreclr/issues/18682
- https://github.com/dotnet/coreclr/issues/19361