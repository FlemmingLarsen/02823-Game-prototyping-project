(
//Define note pickup sound
SynthDef.new(\note, {
	arg freq=40;
	var temp, sum, env;
	sum = 0;
	env = EnvGen.kr(Env.new(
		[0, 1, 0.1, 0],
		[0.03, 1.5, 2],
		[3, -3, 0]),
		doneAction:2);
	3.do{
		temp = SinOsc.ar(
			freq * {Rand(0.99,1.02)}!2,
			{Rand(0.5,1.0)}!2,
			{ExpRand(0.7, 1)}!2
		);
		sum = sum + temp;
	};
	sum = sum * 0.45 * env;
	sum = RHPF.ar(sum, 640);
	sum = Limiter.ar(sum, 1);
	Out.ar(0, sum);
}).add;

//Define lose a note sound
SynthDef.new(\notekill, {
	arg freq=40;
	var temp, sum, env;
	sum = 0;
	env = EnvGen.kr(Env.new(
		[1, 0.5, 0.1, 0],
		[0.1, 1.5, 1],
		[3, -3, 0]),
		doneAction:2);
	2.do{
		temp = SinOsc.ar(
			freq * {Rand(0.99,1.02)}!2,
			{Rand(0.5,1.0)}!2,
			{ExpRand(0.7, 1)}!2
		);
		sum = sum + temp;
	};
	sum = sum * 0.40 * env;
	Out.ar(0, sum);
}).add;

//Define game over sound
SynthDef.new(\gameoversynth, {
	arg freq=40;
	var temp, temp2, sum, env;
	sum = 0;
	freq = XLine.kr(freq, 50, 3, doneAction:2);
	env = EnvGen.kr(Env.new(
		[1, 0.5, 0.1, 0],
		[1, 1, 2],
		[-1, 1, 0]),
		doneAction:2);
	4.do{
		temp = SinOsc.ar(
			freq * {Rand(0.99,1.02)}!2,
			{Rand(0.5,1.0)}!2,
			{ExpRand(0.7, 1)}!2
		);
		temp2 = VarSaw.ar(
			freq * {Rand(0.99,1.02)}!2,
			{Rand(0.1,1.0)}!2,
			{ExpRand(0.1, 1)}!2
		);
		sum = sum + temp + temp2;
	};
	sum = sum * 0.30 * env;
	Out.ar(0, sum);
}).add;

//Define buzzing hum sound
SynthDef.new(\hum, {
	arg freq = 88, amp = 1, speed = 4;
	var flutter, flutterAmt = 0.02, hum, humLevel = 2, sig;

	freq = freq * StandardL.ar(2, 3.7).range(0.97, 1.03);

	hum = Mix(SyncSaw.ar([freq, freq * 1.001], [freq * 1.003, freq * 1.0025]));
	hum = hum * LFNoise0.kr(8.77224).range(0.2, 1.0).lag(0.4);
	hum = RLPF.ar(hum, LFNoise0.kr(21).range(200, 1800).lag(1.2), 0.5) * 0.17 * humLevel;
	hum = hum * SinOsc.kr(speed);
	sig = (hum * amp) ! 2;
	Out.ar(0, sig);
}).add;

//Define wing flap sound
SynthDef.new(\flap, {
	var sig, freq, env, noise;
	env = EnvGen.kr(Env.new(
		[0, 8, 0.3, 0],
		[0.1, 0.3, 0.7],
		[3, -3, 0]),
		doneAction:2);
	freq = XLine.kr(20, 70, 0.2);
	sig = VarSaw.ar(freq * {Rand(0.99,1.22)}!2) * env;
	noise = (PinkNoise.ar(freq) * env * 0.01);
	sig = (sig + noise) * 0.4;
	sig = LPF.ar(
		sig,
		LFNoise1.kr((ExpRand(0.005, 0.55))!8).exprange(40, 120));
	Out.ar(0, sig);
}).add;

//Include sampler to add external sounds
SynthDef(\sampler, {
	arg out = 0, rate = 1, amp = 0.5, buffer = 0;
	var signal;

	signal =
	PlayBuf.ar(1, buffer,
		BufRateScale.kr(buffer)*rate,
		doneAction:2
	);

	Out.ar(out, signal!2 * amp);
}).add;

OSCdef.new(
\note,
	{arg msg;
		[msg].postln;

			[53, 59, 63, 68].do{
			arg midinote;
			Synth.new(\note, [\freq, midinote.midicps]);
		}
	},
	'/note',
	nil, 57120
);

OSCdef.new(
\notedestroy,
	{arg msg;
		[msg].postln;

			[34, 42, 50, 120].do{
			arg midinote;
			Synth.new(\notekill, [\freq, midinote.midicps]);
		}
	},
	'/notedestroy',
	nil, 57120
);

OSCdef.new(
\gameover,
	{arg msg, midinote;
		[msg].postln;
		y.free;

		[24, 32, 40, 50].do{
		Synth.new(\gameoversynth, [\freq, midinote.midicps]);
		}
	},
	'/gameover',
	nil, 57120
);

OSCdef.new(
\flap,
	{arg msg;
		[msg].postln;

			x = Synth.new(\flap);
	},
	'/flap',
	nil, 57120
);

OSCdef.new(
\fly,
	{arg msg;
		[msg].postln;

			y = Synth.new(\hum, [\freq, 88]);

	},
	'/fly',
	nil, 57120
);


s.plotTree;
)