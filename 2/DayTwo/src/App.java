import java.io.BufferedReader;
import java.io.FileReader;
import java.io.IOException;
import java.util.ArrayList;

public class App {
    private static int maxRed = 12;
    private static int maxGreen = 13;
    private static int maxBlue = 14;

    public static void main(String[] args) {
        String filePath = "src/2.txt";
        int sum = 0;

        try (BufferedReader reader = new BufferedReader(new FileReader(filePath))) {
            String line;
            int[] rgb;
            int id = 0;

            while ((line = reader.readLine()) != null) {
                id++;
                System.out.println(line);
                // Process each line here
                rgb = parseLine(line);

                int power = rgb[0] * rgb[1] * rgb[2];
                // System.out.println(power);
                sum += power;
                /*
                 * if (checkValid(rgb)) {
                 * sum += id;
                 * }
                 */

            }
        } catch (IOException e) {
            e.printStackTrace();
        }
        System.out.println(sum);
    }

    public static int[] parseLine(String line) {
        int[] list = { 0, 0, 0 };

        line = line.split(":")[1];
        String[] rounds = line.split("; ");
        for (String round : rounds) {
            for (String part : round.split(",")) {
                updateRGB(list, part.trim());
                printRGB(list);
            }
        }

        return list;
    }

    public static void updateRGB(int[] rgb, String part) {
        if (part.length() < 1) {
            return;
        }
        int num = Integer.parseInt(part.split(" ")[0]);
        switch (part.split(" ")[1]) {
            case "red":
                if (num > rgb[0])
                    rgb[0] = num;
                break;
            case "green":
                if (num > rgb[1])
                    rgb[1] = num;
                break;
            case "blue":
                if (num > rgb[2])
                    rgb[2] = num;
                break;
        }
    }

    public static boolean checkValid(int[] rgb) {
        return (rgb[0] <= maxRed) && (rgb[1] <= maxGreen) && (rgb[2] <= maxBlue);
    }

    public static void printRGB(int[] rgb) {
        System.out.print(rgb[0]);
        System.out.print(" ");
        System.out.print(rgb[1]);
        System.out.print(" ");
        System.out.println(rgb[2]);
    }
}
