#pragma once
#include <string>
#include <Windows.h>

#include "HookMouseEventArg.h"
#include "RemoteServer.h"

constexpr int INPUTBUFFERSIZE = 1024*16;

class RemoteServerPipe final : public RemoteServer
{
	HANDLE _outputPipe = INVALID_HANDLE_VALUE;
	HANDLE _inputPipe = INVALID_HANDLE_VALUE;

	bool StartListener();
	bool StartNotifier();

protected:
    char _inputBuffer[INPUTBUFFERSIZE] = {};
	void RunThread() override
	{
		StartListener() && StartNotifier();
	}

public:
	void Send(const std::string& message) const override;
};


