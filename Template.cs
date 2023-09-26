using System.Text.Encodings.Web;

public static class Template
{

    #region html template


    public static string Htmltp(string filename)
    {
        return $@"
<!DOCTYPE html>
<html lang=""fr"">
<head>
    <meta charset=""UTF-8"">
    <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
    <title>Your Landing Page</title>
    <link rel=""stylesheet"" href=""./{filename}.css"">
</head>
<body>
    <header>
        <nav>
            <div class=""logo"">
                <h1>Your Logo</h1>
            </div>
            <ul class=""nav-links"">
                <li><a href=""#features"">Features</a></li>
                <li><a href=""#about"">About</a></li>
                <li><a href=""#contact"">Contact</a></li>
            </ul>
        </nav>
    </header>

    <section id=""hero"">
        <div class=""hero-content"">
            <h1>Massa tincidunt dui ut ornare molestie nunc.</h1>
            <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit.</p>
            <a href=""#contact"" class=""cta-button"">Get Started</a>
        </div>
    </section>

    <section id=""feature1"">
        <div class=""feature1-content"">
            <h2>Feature 1</h2>
            <p id=""p1"">Les fleurs, véritables joyaux de la nature, captivent par leur diversité de couleurs, de formes et de fragrances. Elles incarnent la beauté éphémère et la délicatesse de la vie. Chaque espèce de fleur raconte son histoire, de la rose romantique à la tulipe élégante, en passant par le soleil éclatant du tournesol. Les fleurs ajoutent une touche de poésie et d'émerveillement à notre monde, symbolisant l'amour, la grâce et la vitalité.</p>
        </div>
        <div class=""feature1-image"">
            <img src=""imgToReplace1"" alt=""About"">
        </div>
    </section>

    <section id=""feature2"">
        <img src=""imgToReplace2"" alt=""About"">
        <div class=""about-content2"">
            <h2>Feature 2</h2>
            <p id=""p2"">Le sport transcende les frontières et les cultures, unifiant les individus dans la passion du mouvement et de l'excellence. Il incarne la discipline, le dévouement et la persévérance. Que ce soit sur un terrain de football, dans une piscine olympique, sur un court de tennis ou dans un stade de basketball, le sport est un véritable spectacle d'efforts humains et de compétition loyale. Il enseigne des leçons de vie inestimables telles que le travail d'équipe, la gestion du stress et la résilience.</p>
        </div>
    </section>

    <section id=""feature3"">
        <div class=""feature1-content"">
            <h2>Feature 3</h2>
            <p  id=""p3"">La mode est un langage silencieux qui exprime notre individualité, notre créativité et notre identité. Elle évolue au fil du temps, reflétant les tendances culturelles, historiques et sociales. Des couleurs vives aux coupes innovantes, la mode est un moyen de se démarquer et de raconter notre histoire au monde. Elle unit les stylistes, les passionnés et les créateurs dans un vaste univers où l'art et la passion se rencontrent pour créer des pièces uniques et intemporelles.</p>
        </div>
        <div class=""feature1-image"">
            <img src=""imgToReplace3"" alt=""About"">
        </div>
    </section>

    <section id=""contact"">
        <h2>Contact Us</h2>
        <a class=""cta-button"">Get Started</a>
    </section>

    <footer>
        <p>&copy; 2023 Your Company</p>
    </footer>
</body>
</html>
";
    }

    public static string Htmltp2()
    {
        return @"<!DOCTYPE html>
<html lang=""en"">
<head>
    <meta charset=""UTF-8"">
    <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
    <title>Your Landing Page</title>
    <link rel=""stylesheet"" href=""./autre.css"">
</head>
<body>
    <header>
        <nav>
            <ul class=""nav-links"">
                <li><a href=""#features"">Features</a></li>
                <li><a href=""#about"">About</a></li>
                <li><a href=""#contact"">Contact</a></li>
            </ul>
        </nav>
    </header>

    <section id=""hero"">
        <div class=""hero-content"">
            <h1>Welcome to Our Landing Page</h1>
            <p>Discover amazing products and services that will change your life.</p>
            <a href=""#contact"" class=""cta-button"">Get Started</a>
        </div>
    </section>

    <section id=""features"">
        <div class=""feature"">
            <img src=""../images/feature1.png"" alt=""Feature 1"">
            <h2>Feature 1</h2>
            <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit.</p>
        </div>

        <div class=""feature"">
            <img src=""../images/feature2.png"" alt=""Feature 2"">
            <h2>Feature 2</h2>
            <p>Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.</p>
        </div>

        <div class=""feature"">
            <img src=""../images/feature3.png"" alt=""Feature 3"">
            <h2>Feature 3</h2>
            <p>Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur.</p>
        </div>
    </section>

    <section id=""about"">
        <div class=""about-content"">
            <h2>About Us</h2>
            <p>Learn more about our company and how we're making a difference in the industry.</p>
            <a href=""#contact"" class=""cta-button"">Learn More</a>
        </div>
    </section>

    <footer>
        <p>&copy; 2023 Your Company</p>
    </footer>
</body>
</html>";
    }

    #endregion


    #region css template
    public static string Csstp()
    {
        return @"
/* Reset some default styles */
* {
    margin: 0;
    padding: 0;
    box-sizing: border-box;
}

/* Apply a background color and font styles */
body {
    font-family: Arial, sans-serif;
    background-color: #f4f4f4;
    color: #333;
    line-height: 1.6;
    margin: 0;
    padding: 0;
}

/* Style the header and navigation */
header {
    background-color: #333;
    color: #fff;
    padding: 20px 0;
}

nav {
    max-width: 1200px;
    margin: 0 auto;
    display: flex;
    justify-content: space-between;
    align-items: center;
}

.logo {
    font-size: 24px;
    font-weight: bold;
}

.nav-links {
    list-style: none;
    display: flex;
}

.nav-links li {
    margin-right: 20px;
}

.nav-links a {
    text-decoration: none;
    color: #fff;
    font-weight: bold;
}

/* Style the hero section */
#hero {
    background-image: url('hero-background.jpg');
    background-size: cover;
    text-align: center;
    padding: 100px 0;
}

.hero-content h1 {
    font-size: 36px;
    margin-bottom: 20px;
}

.cta-button {
    display: inline-block;
    padding: 10px 20px;
    background-color: #ff6600;
    color: #fff;
    text-decoration: none;
    font-weight: bold;
    border-radius: 5px;
}

/* Style the feature section */
#features {
    max-width: 1200px;
    margin: 0 auto;
    padding: 80px 0;
    display: flex;
    justify-content: space-between;
}

.feature {
    text-align: center;
    flex-basis: 30%;
}

#feature2 {
    display: flex;
    align-items: center;
    width: 100%;
    flex-direction: row;
}

#feature2 img {
    margin-right: 10px;
}

#feature2 .about-content2 {
    height: 100%;
}

.feature img {
    max-width: 100px;
    margin-bottom: 20px;
}

/* Style the about section */
#feature1, #feature3 {
    background-color: #fff;
    text-align: center;
    padding: 80px 0;
    display: flex;
    justify-content: center; /* Center the content horizontally */
    align-items: center; /* Center the content vertically */
}

.feature1-content {
    max-width: 600px; /* Adjust the width as needed */
    text-align: left; /* Align text to the left */
    margin-right: 20px; /* Add space between text and image */
}
.about-content2 {
    max-width: 600px; /* Adjust the width as needed */
    text-align: right; /* Align text to the left */
    margin-right: 20px; /* Add space between text and image */
}

.feature1-image {
    max-width: 400px; /* Adjust the width as needed */
}

/* Responsive design for smaller screens */
@media (max-width: 768px) {
    .about {
        flex-direction: column; /* Stack content on smaller screens */
        text-align: center;
    }

    .about-content,
    .about-image {
        max-width: 100%; /* Make content full-width on smaller screens */
        margin: 0; /* Reset margin for stacking */
    }
}

/* Style the contact section */
#contact {
    max-width: 600px;
    margin: 0 auto;
    text-align: center;
    padding: 80px 0;
}

form label {
    display: block;
    margin-bottom: 10px;
    font-weight: bold;
}

form input[type=""text""],
form input[type=""email""],
form textarea {
    width: 100%;
    padding: 10px;
    margin-bottom: 20px;
    border: 1px solid #ccc;
    border-radius: 5px;
}

form button[type=""submit""] {
    background-color: #ff6600;
    color: #fff;
    padding: 10px 20px;
    border: none;
    border-radius: 5px;
    cursor: pointer;
}

/* Style the footer */
footer {
    background-color: #333;
    color: #fff;
    text-align: center;
    padding: 20px 0;
}

/* Responsive design for smaller screens */
@media (max-width: 768px) {
    header {
        padding: 10px 0;
    }

    .nav-links {
        display: none;
        flex-direction: column;
        text-align: center;
        position: absolute;
        top: 60px;
        right: 0;
        background-color: #333;
        width: 100%;
        z-index: 1;
    }

    .nav-links.active {
        display: flex;
    }

    .nav-links li {
        margin: 0;
        margin-bottom: 10px;
    }
}
";
    }

    #endregion

    #region js template
    // public static string jstp(string img1, string img2, string img3)
    // {
    //     return $@"
    // document.getElementById('img1').src="img1"; document.getElementById('img2').src="img2"; document.getElementById('img3').src="img3";";
    // }
    #endregion
}