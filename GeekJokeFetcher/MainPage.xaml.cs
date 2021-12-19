using System;
using System.Net.Http;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Essentials;

namespace GeekJokeFetcher
{
	public partial class MainPage : ContentPage
    {
        private readonly HttpClient _http = new HttpClient();

        public MainPage()
		{
			InitializeComponent();
		}

		private async void FetchJoke(object sender, EventArgs e)
        {
            GeekJoke.Text = "Fetching a new joke...";

			HttpResponseMessage response = await _http.GetAsync("https://geek-jokes.sameerkumar.website/api?format=text");
            GeekJoke.Text = await response.Content.ReadAsStringAsync();

			SemanticScreenReader.Announce(GeekJoke.Text);
		}
	}
}
