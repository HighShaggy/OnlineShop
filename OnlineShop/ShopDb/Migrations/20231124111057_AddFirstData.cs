using Microsoft.EntityFrameworkCore.Migrations;

namespace ShopDb.Migrations
{
    public partial class AddFirstData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ProductDb",
                columns: new[] { "Id", "Cost", "Description", "ImagePath", "Name" },
                values: new object[,]
                {
                    { 1, 6999m, "Ультра-легкая конструкция Уникальный, праворукий дизайн Сенсор pixart 3389 Провод xtrfy ezcord", "~/images/products/XtrfyRetro.webp", "Xtrfy Retro Edition" },
                    { 2, 7999m, "В игровой мыши Logitech G403 HERO используется новейший датчик HERO 25K.Этот датчик обеспечивает отслеживание без задержек на скорости более 10 м/с (400 дюйм/с) при уровне чувствительности от 100 до 25 600 точек на дюйм.", "~/images/products/logitechG403.webp", "Logitech G G403 Hero" },
                    { 3, 8999m, "Мышь проводная Xtrfy M4 RGB Tokyo отличается от многих моделей облегченным перфорированным корпусом. Слегка изогнутый корпус удобно лежит в правой руке, снимая лишнее напряжение с запястья.", "~/images/products/XtrfyTokyoEdition.webp", "Xtrfy Tokyo Edition" },
                    { 4, 4090m, "Мышь проводная SteelSeries Rival 3 - оптимальный вариант для прохождения игр любой жанровой направленности.", "~/images/products/SteelseriesRival3.webp", "Steelseries Rival 3" },
                    { 5, 6060m, "Дизайн и габариты SteelSeries Sensei очень напоминают легендарную мышь SteelSeries Xai Laser, которая может похвастать отличной эргономикой. Корпус имеет симметричную форму, и поэтому манипулятор подходит как правшам, так и левшам.", "~/images/products/SteelseriesSensei.webp", "Steelseries Sensei" },
                    { 6, 12990m, "Игровая клавиатура SteelSeries Apex 5 Keyboard RU чёрная Корпус SteelSeries Apex 5 — это монолитная пластина, изготовленная из авиационного алюминия Series 5000, который отличается исключительной прочностью и надежностью. ", "~/images/products/SteelseriesApex.webp", "Steelseries Apex" },
                    { 7, 10999m, "Клавиатура Logitech G Pro представлена в строгом черном корпусе и обладает многочисленными функциями, которые делают ее идеальным инструментом для игр. Это механическая клавиатура с переключателями GX Blue.", "~/images/products/LogitechGpro.webp", "Logitech G Pro" },
                    { 8, 8990m, "Беспроводная клавиатура Logitech POP Keys. Круглые клавиши модели напоминают клавиши печатной машинки. Звук при печати довольно громкий и для срабатывания нужно сделать довольно сильное нажатие.", "~/images/products/LogitechPopKeys.webp", "Logitech Pop keys" },
                    { 9, 2990m, "Игровой коврик Steelseries QcK Edge M размерами 32х27 см отлично подходит для яростных виртуальных сражений. Стильный аксессуар легко сочетается с другими геймерскими комплектующими.", "~/images/products/SteelseriesQck.webp", "Steelseries Qck edge" },
                    { 10, 3990m, "Большой игровой коврик для мыши. Patrik \"F0REST\" Lindberg EDITION.", "~/images/products/XtrfyForestEdition.webp", "Xtrfy Forest Edition" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProductDb",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ProductDb",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ProductDb",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ProductDb",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ProductDb",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ProductDb",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "ProductDb",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "ProductDb",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "ProductDb",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "ProductDb",
                keyColumn: "Id",
                keyValue: 10);
        }
    }
}
