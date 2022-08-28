using System;
using System.Diagnostics;
using System.IO;

// Token: 0x02000002 RID: 2
internal class AsyncStreamReader
{
	// Token: 0x14000001 RID: 1
	// (add) Token: 0x06000001 RID: 1 RVA: 0x00002048 File Offset: 0x00000248
	// (remove) Token: 0x06000002 RID: 2 RVA: 0x00002080 File Offset: 0x00000280

	public event AsyncStreamReader.EventHandler<string> ValueRecieved;

	// Token: 0x17000001 RID: 1
	// (get) Token: 0x06000003 RID: 3 RVA: 0x000020B5 File Offset: 0x000002B5
	// (set) Token: 0x06000004 RID: 4 RVA: 0x000020BD File Offset: 0x000002BD
	public bool Active { get; private set; }

	// Token: 0x06000005 RID: 5 RVA: 0x000020C6 File Offset: 0x000002C6
	public AsyncStreamReader(StreamReader reader)
	{
		this._reader = reader;
		this._buffer = new byte[4096];
		this.Active = false;
	}

	// Token: 0x06000006 RID: 6 RVA: 0x000020F0 File Offset: 0x000002F0
	protected void Begin()
	{
		bool active = this.Active;
		bool flag = active;
		if (flag)
		{
			this._reader.BaseStream.BeginRead(this._buffer, 0, this._buffer.Length, new AsyncCallback(this.Read), null);
		}
	}

	// Token: 0x06000007 RID: 7 RVA: 0x0000213C File Offset: 0x0000033C
	public void Start()
	{
		bool flag = !this.Active;
		bool flag2 = flag;
		if (flag2)
		{
			this.Active = true;
			this.Begin();
		}
	}

	// Token: 0x06000008 RID: 8 RVA: 0x0000216A File Offset: 0x0000036A
	public void Stop()
	{
		this.Active = false;
	}

	// Token: 0x06000009 RID: 9 RVA: 0x00002178 File Offset: 0x00000378
	private void Read(IAsyncResult result)
	{
		bool flag = this._reader != null;
		bool flag2 = flag;
		if (flag2)
		{
			int num = this._reader.BaseStream.EndRead(result);
			string value = string.Empty;
			bool flag3 = num > 0;
			bool flag4 = flag3;
			if (flag4)
			{
				value = this._reader.CurrentEncoding.GetString(this._buffer, 0, num);
			}
			else
			{
				this.Active = false;
			}
			AsyncStreamReader.EventHandler<string> valueRecieved = this.ValueRecieved;
			bool flag5 = valueRecieved != null;
			if (flag5)
			{
				valueRecieved(this, value);
			}
			this.Begin();
		}
	}

	// Token: 0x04000003 RID: 3
	private StreamReader _reader;

	// Token: 0x04000004 RID: 4
	protected readonly byte[] _buffer;

	// Token: 0x02000014 RID: 20
	// (Invoke) Token: 0x06000084 RID: 132
	public delegate void EventHandler<Args>(object sender, string value);
}
