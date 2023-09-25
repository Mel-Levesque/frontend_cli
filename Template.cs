using System.Text.Encodings.Web;

public static class Template
{
    public static string Htmltp(string filename)
    {
        return $@"
<!DOCTYPE html>
<html lang=""en"">
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
            <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nulla aliquet bibendum sem, eu interdum nulla cursus a.</p>
        </div>
        <div class=""feature1-image"">
            <img src=""../images/businessman.png"" alt=""About"">
        </div>
    </section>

    <section id=""feature2"">
        <img src=""../images/businessman.png"" alt=""About"">
        <div class=""about-content2"">
            <h2>Feature 2</h2>
            <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nulla aliquet bibendum sem, eu interdum nulla cursus a.</p>
        </div>
    </section>

    <section id=""feature3"">
        <div class=""feature1-content"">
            <h2>Feature 3</h2>
            <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nulla aliquet bibendum sem, eu interdum nulla cursus a.</p>
        </div>
        <div class=""feature1-image"">
            <img src=""../images/businessman.png"" alt=""About"">
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
}