import org.json.JSONObject;

public class JSONBuoy {

	public static void main(String[] args) {
		// TODO Auto-generated method stub
		String msg = "{\"name\":\"abc\"}";
		JSONObject ob = new JSONObject(msg);
		System.out.println(ob.get("name"));
	}

}