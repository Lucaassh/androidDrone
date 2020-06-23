package com.example.droneone.ui.gallery;

import android.content.Intent;
import android.net.Uri;
import android.os.Bundle;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.webkit.WebSettings;
import android.webkit.WebView;
import android.webkit.WebViewClient;
import android.widget.TextView;

import androidx.annotation.NonNull;
import androidx.annotation.Nullable;
import androidx.fragment.app.Fragment;
import androidx.lifecycle.Observer;
import androidx.lifecycle.ViewModelProviders;

import com.example.droneone.R;

public class GalleryFragment extends Fragment {

    private String HOST = "http://192.168.15.8/DroneOne";


    private GalleryViewModel galleryViewModel;


    public View onCreateView(@NonNull LayoutInflater inflater,
                             ViewGroup container, Bundle savedInstanceState) {

        galleryViewModel =
                ViewModelProviders.of(this).get(GalleryViewModel.class);
        View root = inflater.inflate(R.layout.fragment_gallery, container, false);
        final TextView textView = root.findViewById(R.id.text_gallery);
        galleryViewModel.getText().observe(getViewLifecycleOwner(), new Observer<String>() {
            @Override
            public void onChanged(@Nullable String s) {
                textView.setText(s);
            }
        });

        WebView myWebView = (WebView) root.findViewById(R.id.webPerfil);
        myWebView.loadUrl("http://3.16.43.88/index.php");
        myWebView.setWebViewClient(new WebViewClient());
        WebSettings webSettings = myWebView.getSettings();
        webSettings.setJavaScriptEnabled(true);

        return root;
    }
    private class MyWebViewClient extends WebViewClient {
        @Override
        public boolean shouldOverrideUrlLoading(WebView view, String url) {
            if (Uri.parse(url).getHost().equals("http://3.16.43.88/index.php")) {
                return false;

            }

            Intent intent = new Intent(Intent.ACTION_VIEW, Uri.parse(url));
            startActivity(intent);
            return true;
        }
    }

}