# how-to-show-busy-indicator-in-each-item-in-.net-maui-listview

This example demonstrates about how to show the busy indicator in each item until it's content is loaded in .NET MAUI ListView.

## Sample

```xaml
<sync:SfListView x:Name="listView" AutoFitMode="Height" BackgroundColor="#d3d3d3" SelectionMode="None" ItemsSource="{Binding NewBookInfo}">
    <sync:SfListView.ItemTemplate>
        <DataTemplate>
            <Frame HasShadow="True" Margin="5,5,5,0">
                <Grid Padding="5">
                    <Grid.RowDefinitions>
                        <RowDefinition Height="*" />
                        <RowDefinition Height="2*" />
                    </Grid.RowDefinitions>
                    <Label Text="{Binding BookName}" FontAttributes="Bold" FontSize="18" />
                    <Button Grid.Row="1" Clicked="Button_Clicked" Text="Load Description" IsVisible="{Binding IsButtonVisible}" HorizontalOptions="Center" VerticalOptions="Center"/>
                    <Label Grid.Row="1" Text="{Binding BookDescription}" FontSize="15" IsVisible="{Binding IsDescriptionVisible}" />
                    <ActivityIndicator Grid.Row="1" IsEnabled="True" IsRunning="True" IsVisible="{Binding IsIndicatorVisible}" />
                </Grid>
            </Frame>
        </DataTemplate>
    </sync:SfListView.ItemTemplate>
</sync:SfListView>
```

## Requirements to run the demo

* [Visual Studio 2017](https://visualstudio.microsoft.com/downloads/) or [Visual Studio for Mac](https://visualstudio.microsoft.com/vs/mac/)
* Xamarin add-ons for Visual Studio (available via the Visual Studio installer).

## Troubleshooting

### Path too long exception

If you are facing path too long exception when building this example project, close Visual Studio and rename the repository to short and build the project.
