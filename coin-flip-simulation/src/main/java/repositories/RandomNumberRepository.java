package repositories;

import models.RandomNumber;
import okhttp3.OkHttpClient;
import okhttp3.Request;
import okhttp3.Response;
import okhttp3.ResponseBody;

import java.io.IOException;

public class RandomNumberRepository implements IRandomNumberRepository {
    OkHttpClient client = new OkHttpClient();

    @Override
    public RandomNumber getRandomNumber() {
        Request request = new Request.Builder()
                .url("https://www.random.org/integers/?num=1&min=1&max=2&col=1&base=10&format=plain&rnd=new")
                .build();

        try {
            Response response = client.newCall(request).execute();
            ResponseBody responseBody = response.body();
            RandomNumber randomNumber = null;

            if (responseBody != null) {
                randomNumber = RandomNumber.fromString(responseBody.string().trim());
            }

            client.connectionPool().evictAll();

            return randomNumber;
        } catch (IOException exc) {
            return null;
        }
    }
}
