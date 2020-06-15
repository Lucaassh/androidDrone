package com.example.droneone.ui.gallery;

import android.os.Bundle;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Button;
import android.widget.EditText;
import android.widget.TextView;

import androidx.annotation.NonNull;
import androidx.annotation.Nullable;
import androidx.fragment.app.Fragment;
import androidx.lifecycle.Observer;
import androidx.lifecycle.ViewModelProviders;

import com.example.droneone.R;
import com.google.gson.JsonObject;
import com.koushikdutta.async.future.Future;
import com.koushikdutta.async.future.FutureCallback;
import com.koushikdutta.ion.Ion;

public class GalleryFragment extends Fragment {

    private String HOST = "http://192.168.15.8/DroneOne";


    private GalleryViewModel galleryViewModel;


    public View onCreateView(@NonNull LayoutInflater inflater,
                             ViewGroup container, Bundle savedInstanceState) {

        EditText editNome = null, editUsuario = null, editSexo = null, EditCep = null;
        Button btnAnexar = null;

        View vroot = inflater.inflate(R.layout.fragment_gallery, container, false);

        editNome = (EditText) vroot.findViewById(R.id.editNome);
        editUsuario = (EditText) vroot.findViewById(R.id.editUsuario);
        editSexo = (EditText) vroot.findViewById(R.id.editSexo);
        EditCep = (EditText) vroot.findViewById(R.id.EditCep);

        btnAnexar = (Button) vroot.findViewById(R.id.btnAnexar);

        EditText finalEdiNome = editNome;
        EditText finalEditUsuario = editUsuario;
        EditText finalEditSexo = editSexo;
        EditText finalEditCep = EditCep;

        btnAnexar.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view)
            {
                String nome = finalEdiNome.getText().toString();
                String usuario = finalEditUsuario.getText().toString();
                String sexo = finalEditSexo.getText().toString();
                String cep = finalEditCep.getText().toString();

                String url = HOST + "/insert.php";


                Future<JsonObject> jsonObjectFuture = Ion.with(GalleryFragment.this)
                        .load(url)
                        .setBodyParameter("nome", nome)
                        .setBodyParameter("usuario", usuario)
                        .setBodyParameter("sexo", sexo)
                        .setBodyParameter("cep", cep)
                        .asJsonObject()
                        .setCallback(new FutureCallback<JsonObject>() {
                            @Override
                            public void onCompleted(Exception e, JsonObject result) {
                                // do stuff with the result or error

                            }
                        });
            }

        });

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
        return root;

    }

}