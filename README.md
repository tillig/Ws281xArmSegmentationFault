# WS281x ARM Segmentation Fault

I'm using a Raspberry Pi 3B+ with Raspbian trying to control a string of WS2812B lights with [a common library](https://github.com/jgarff/rpi_ws281x) that interfaces via the GPIO pins.

I've found that I inconsistently get a segmentation fault somewhere around the P/Invoke area. This repo is about creating a minimal reproduction that can be used for troubleshooting and illustrating the issue.