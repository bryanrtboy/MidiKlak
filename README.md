MidiKlak
========

*MidiKlak-Learn* is based on *MidiKlak*, an extension for [Klak][Klak], that provides functionality for
receiving MIDI messages from physical/virtual MIDI devices.

![gif](http://49.media.tumblr.com/6eb313a0e36f25195e470d59839a530a/tumblr_o1mcacuoft1qio469o1_400.gif)

System Requirements
-------------------

- Unity 5
- Windows or Mac OS X

*MidiKlak-Learn* has dependency to the following packages. Please import them before
installing *MidiKlak-Learn*.

- [Klak][Klak]
- [MidiJack][MidiJack]

How To Use It
-------------

*MidiKlak*-Learn provides two components -- **NoteLearnInput** and **KnobLearnInput**.

- **NoteLearnInput** - receives MIDI note messages and invokes Unity events
  with input values (note number and velocity).
- **KnobLearnInput** - receives MIDI CC (control change) messages and invokes
  Unity events with a single float value.

In addition we have **LearnCC** and **LearnNote**.
- **LearnCC** - is attached to a UI Button (radial) and visually shows input from a CC Knob
- **LearnNote** - is attached to a UI Button and is on/off based on input.

Both Buttons can be clicked to enter a **Learn** state, the next input from MIDI sets the button or knob to that particular knob.

**SetCC** and **SetNote** will read from the PlayerPreference and set based on the last time Midi-Learn was run.


For further details of usage, please refer to [MidiKlak][MidiKlak], which contain sample scenes in the "Samples"
directory (these were deleted from *MidiKlak-Learn*).

[Klak]: https://github.com/keijiro/Klak
[MidiJack]: https://github.com/keijiro/MidiJack

License
-------

Copyright (C) 2016 Keijiro Takahashi

Permission is hereby granted, free of charge, to any person obtaining a copy of
this software and associated documentation files (the "Software"), to deal in
the Software without restriction, including without limitation the rights to
use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of
the Software, and to permit persons to whom the Software is furnished to do so,
subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS
FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR
COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER
IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN
CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
