# coronaManagementSystem
A corona management system website  
שלום
בתקיה זו תראו 2 תקיות 
תקיה ראשונה הינה מערכת corona management system website מערכת ניהול מאגר קורונה לקופת חולים גדולה.
מערכת זו מציגה את החברים בקופת החולים, מנהלת הכנסה ומחיקה ושליפה של רשומות במאגר המידע כמו כן, המערכת אוגרת את פרטי המפתח לגבי מגיפת הקורונה בהקשרי החברים בקופת החולים כדי שיוכלו בעתיד לפנות למאגר לצורך ביצוע שליפות שונות.
ביצירת מערכת זו התמקדתי בעיקר בצד שרת ובניית מאגר נתונים, צד לקוח יצרתי בצורה בסיסית כדי שאוכל להציג את ביצועי המערכת.
בצד שרת התמקדתי בבדיקות שונות לשים לב לתקינות הקלטים ולמנוע טעויות שונות ונציג את חלקם בצילומי מסך.

את מערכת זו יצרתי בסביבת נעבודה visualstudio עם הטכנולוגיה ASP.NET Core שהיתה מאוד נוחה לשימוש,ASP.NET היא טכנולוגית קוד פתוח ליישומי אינטרנט בצד השרת, שפותחה על ידי חברת microsoft.באמצעות ASP.NET ניתן ליצור אתרי אינטרנט דינמיים בשילוב נתונים מבסיסי נתונים, ולטפל בטפסים ובמידע שנשלחים מהמשתמשים. התפקיד של ASP.NET הוא לנתח את המידע וליצור פלט בהתאם, את טכנולוגיה זו לא הכרתי לפני ולמדתי אותה בשביל הפרויקט ומאוד נהנתי ממנה ומעצם הלימידה של טכנולוגיה חדשה.את צד שרת כתבתי בשפת בC# שהינה מאוד שימושית ונוחה לעבוד עם טכנולוגית ASP.NET 
קישור לסביבת העבודה 

https://visualstudio.microsoft.com/downloads/


השתמשתי בSQL Server Express שפותח על ידי חברת microsoft כמאגר נתונים קישור לSQL Server Express
https://www.microsoft.com/en-us/sql-server/sql-server-downloads

אופן השימוש במערכת
דף הבית בו נוכל לבחור על הלחצן של Client שיביא אותנו לדף המציג את החברים בקופת החולים
Main Page
![image](https://github.com/RachelEliU/coronaManagementSystem/assets/116077153/e6cb323f-fe25-4011-9b1d-75a9ba60bb11)

דף זה מציג את החברים בקופת החולים ואופציות שונות של המערכת
Client Page
![image](https://github.com/RachelEliU/coronaManagementSystem/assets/116077153/c9a389ef-b87b-4af1-987c-872c834339b1)

במידה ולחצנו על הלחצן Create נגיע לדף בו נוכל להזין את פרטי הלקוח ולשמור אותם במערכת, כמובן שהמערכת תבדוק לפי השמירה שאכן כל הערכים תקינים.
Create new client

![image](https://github.com/RachelEliU/coronaManagementSystem/assets/116077153/fe1ecfea-e488-4d57-8f32-90ef4ad31d14)
 
 במידה ולא הכנסנו תעודת זהות תקינה המערכת תזהה ותציג הודעה על כך
 
 ![image](https://github.com/RachelEliU/coronaManagementSystem/assets/116077153/a9a1be3b-f3e2-4eef-8eae-3b448343e637)

במידה ואחד מנתוני הזיהוי חסרים המערכת תציג הודעה עך כך
![image](https://github.com/RachelEliU/coronaManagementSystem/assets/116077153/f70ccae4-ff27-407f-b13d-75f18a3786ef)

 Details about client
 ![image](https://github.com/RachelEliU/coronaManagementSystem/assets/116077153/e89a93a2-ad0f-475c-9443-6934eb38b9bf)
