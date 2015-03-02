<asp:Button ID="ButtonShowVideo" runat="server" 
   onclick="ButtonShowVideo_Click" Text="Show Video" />

    <asp:Repeater ID="Repeater1" runat="server">
        <ItemTemplate>
            <object id="player" 
                       classid="clsid:6BF52A52-394A-11D3-B153-00C04F79FAA6" 
                       height="170" width="300">
                <param name="url" 
                  value='<%# "VideoHandler.ashx?id=" + Eval("ID") %>'/>
                <param name="showcontrols" value="true" />
                <param name="autostart" value="true" />
            </object>
        </ItemTemplate>
    </asp:Repeater>